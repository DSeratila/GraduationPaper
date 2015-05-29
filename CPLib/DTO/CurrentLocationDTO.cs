using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GPLib.DTO
{
    [DataContract]
    public class CurrentLocationDTO
    {
        [DataMember]
        public int LocationId { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longtitude { get; set; }
        [DataMember]
        public System.DateTime LastUpdated { get; set; }
    }
}
