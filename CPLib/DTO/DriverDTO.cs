using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace GPLib.DTO
{
    /// <summary>
    /// DTO объект для Driver, чтобы не сериализовать лишнее
    /// </summary>
    [DataContract]
    public class DriverDTO
    {
        [DataMember]
        public int DriverId { get; set; }
        [DataMember]
        public string DriverName { get; set; }
        [DataMember]
        public string PhoneNum { get; set; }
        [DataMember]
        public string LicenceNum { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public string PassportSeries { get; set; }
        [DataMember]
        public string PassportNum { get; set; }
        [DataMember]
        public string PassportGivenBy { get; set; }
        [DataMember]
        public Nullable<System.DateTime> PassportGivenDate { get; set; }
        [DataMember]
        public string PassportGivenDivision { get; set; }
        [DataMember]
        public Nullable<bool> IsDeleted { get; set; }
    }
}
