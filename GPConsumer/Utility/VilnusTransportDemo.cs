using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GPConsumer.Utility
{
    public struct VehicleData
    {
        public int Id;
        public double Lat;
        public double Lng;
        public string Line;
        public string LastStop;
        public string TrackType;
        public string AreaName;
        public string StreetName;
        public string Time;
        public double? Bearing;
    }

    public class VilnusTransportDemo
    {
        public static void GetVilniusTransportData( string line, List<VehicleData> ret)
        {
            ret.Clear();
            Random r = new Random();
            //http://stops.lt/vilnius/gps.txt?1318577178193
            //http://www.marsrutai.lt/vilnius/Vehicle_Map.aspx?trackID=34006&t=1318577231295
            // http://www.troleibusai.lt/eismas/get_gps.php?allowed=true&more=1&bus=1&rand=0.5487859781558404

            string url = string.Format(CultureInfo.InvariantCulture, "http://www.troleibusai.lt/eismas/get_gps.php?allowed=true&more=1&bus={0}&rand={1}", 2 , r.NextDouble());

            if (!string.IsNullOrEmpty(line))
            {
                url += "&nr=" + line;
            }
            url += "&app=GMap.NET.Desktop";


            string xml = string.Empty;
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.UserAgent = GMapProvider.UserAgent;
                request.Timeout = GMapProvider.TimeoutMs;
                request.ReadWriteTimeout = GMapProvider.TimeoutMs * 6;
                request.Accept = "*/*";
                request.KeepAlive = true;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader read = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            xml = read.ReadToEnd();
                        }
                    }
                    response.Close();
                }
            }
            StringBuilder a = new StringBuilder();
            // 54.690688; 25.2116; 1263522; 1; 48.152; 2011-10-14 14:41:29

            if (!string.IsNullOrEmpty(xml))
            {
                var items = xml.Split('&');

                foreach (var it in items)
                {
                    var sit = it.Split(';');
                    if (sit.Length == 8)
                    {
                        VehicleData d = new VehicleData();
                        {
                            d.Id = int.Parse(sit[2]);
                            a.Append(d.Id.ToString()+";");
                            d.Lat = double.Parse(sit[0], CultureInfo.InvariantCulture);
                            a.Append(d.Lat.ToString().Replace(',','.') + ";");
                            d.Lng = double.Parse(sit[1], CultureInfo.InvariantCulture);
                            a.Append(d.Lng.ToString().Replace(',', '.') + ";");
                            d.Line = sit[3];
                            if (!string.IsNullOrEmpty(sit[4]))
                            {
                                d.Bearing = double.Parse(sit[4], CultureInfo.InvariantCulture);
                            }

                            if (!string.IsNullOrEmpty(sit[5]))
                            {
                                d.Time = sit[5];
                                a.Append("'20151705 "+ d.Time + "'\n");
                                var t = DateTime.Parse(d.Time);
                                if (DateTime.Now - t > TimeSpan.FromMinutes(5))
                                {
                                    continue;
                                }

                                d.Time = t.ToLongTimeString();
                            }

                            d.TrackType = sit[6];
                        }

                        //if(d.Id == 1262760)
                        //if(d.Line == "13")
                        {
                            ret.Add(d);
                        }

                    }
                }
                string b = a.ToString();
            }
     
        }
    }
}
