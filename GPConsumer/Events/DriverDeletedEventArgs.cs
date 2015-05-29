using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPConsumer.Events
{
    public class DriverDeletedEventArgs : System.EventArgs
    {
        private int deletedDriverId;

        /// <summary>
        /// Идентификатор отредактированного водителя
        /// </summary>
        public int DeletedDriverId
        {
            get { return deletedDriverId; }
        }

        public DriverDeletedEventArgs(int deletedDriverId)
        {
            this.deletedDriverId = deletedDriverId;
        }
    }
}
