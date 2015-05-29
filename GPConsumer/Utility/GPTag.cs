using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPConsumer.Utility
{
    public class GPTag
    {
        int orderId;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        int? driverId;

        public int? DriverId
        {
            get { return driverId; }
            set { driverId = value; }
        }

        public GPTag(int orderId, int? driverId)
        {
            this.driverId = driverId;
            this.orderId = orderId;
        }
    }
}
