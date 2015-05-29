using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLib.DTO
{
   public class OrderStatDTO
    {
        public Nullable<int> OrderId { get; set; }
        public Nullable<System.DateTime> dt { get; set; }
        public string descr { get; set; }
    }
}
