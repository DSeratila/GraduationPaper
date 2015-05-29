using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPLib.DTO
{
    [DataContract]
   public class DriverStatisticsDTO
    {
         [DataMember]
        public Nullable<int> RowId { get; set; }
         [DataMember]
        public int DriverId { get; set; }
         [DataMember]
        public double Latitude { get; set; }
         [DataMember]
        public double Longtitude { get; set; }
         [DataMember]
        public Nullable<System.DateTime> LastUpdated { get; set; }
         [DataMember]
        public double Bearing { get; set; }
         [DataMember]
        public Nullable<double> Distance { get; set; }
    }
}
