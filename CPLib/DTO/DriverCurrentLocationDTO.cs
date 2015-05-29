using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GPLib.DTO
{
    [DataContract]
   public class DriverCurrentLocationDTO
    {
        [DataMember]
        public int DriverId { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longtitude { get; set; }
        [DataMember]
        public System.DateTime LastUpdated { get; set; }
        //[DataMember]
        //public string VehicleName;
        [DataMember]
        public string DriverName;
        //[DataMember]
        //public int DriverId;

        [DataMember]
        public System.TimeSpan VehicleTime { get; set; }

    }
}
