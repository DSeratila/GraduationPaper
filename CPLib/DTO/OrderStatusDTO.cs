using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GPLib.DTO
{
    [DataContract]
   public class OrderStatusDTO
    {
        [DataMember]
        public int OrderStatusId { get; set; }
        [DataMember]
        public string OrderStatusName { get; set; }
    }
}
