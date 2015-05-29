using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GPLib.DTO
{
    [DataContract]
   public class VehicleDTO
    {
        [DataMember]
        public int VehicleId { get; set; }
        [DataMember]
        public int DriverId { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string LicencePlate { get; set; }
        [DataMember]
        public Nullable<decimal> Lenght { get; set; }
        [DataMember]
        public Nullable<decimal> Width { get; set; }
        [DataMember]
        public Nullable<decimal> Height { get; set; }
        [DataMember]
        public Nullable<decimal> Capacity { get; set; }
        //public Nullable<decimal> Latitude { get; set; }
        //public Nullable<decimal> Longtitude { get; set; }
        //public Nullable<System.DateTime> LastSeen { get; set; }

        [DataMember]
        public string VehicleName { get; set; }
    }
}
