using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GPLib.DTO
{
    [DataContract]
   public class OrderDTO
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CreatedDt { get; set; }
        [DataMember]
        public Nullable<System.DateTime> DeliveredDt { get; set; }
        [DataMember]
        public string DeliveryAdress { get; set; }
        [DataMember]
        public Nullable<double> Latitude { get; set; }
        [DataMember]
        public Nullable<double> Longtitude { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public Nullable<int> OrderStatusId { get; set; }
        [DataMember]
        public string OrderStatusName { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string GoodsList { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public Nullable<decimal> TotalCost { get; set; }
        [DataMember]
        public System.DateTime UpdateDt { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public System.DateTime LastUpdated { get; set; }
        [DataMember]
        public Nullable<int> DeliveryDriverId { get; set; }
        [DataMember]
        public string DeliveryDriverName { get; set; }
    }
}
