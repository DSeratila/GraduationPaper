using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPConsumer.Events
{

     public class DriverCreatedEventArgs : System.EventArgs
    {
        private int createdDriverId;

        public int CreatedDriverId
        {
            get { return createdDriverId; }
        }

        public DriverCreatedEventArgs(int createdDriverId)
        {
            this.createdDriverId = createdDriverId;
        }
    }

    

}
