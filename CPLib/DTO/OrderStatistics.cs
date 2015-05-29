using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPLib.DTO
{
    [DataContract]
    public class OrderStatistics
    {
        [DataMember]
        public Nullable<int> OrderId { get; set; }
        [DataMember]
        public Nullable<System.DateTime> dt { get; set; }
        [DataMember]
        public string descr { get; set; }
    }
}
