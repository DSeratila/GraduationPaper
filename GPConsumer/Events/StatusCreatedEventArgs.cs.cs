using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPConsumer.Events
{
    public class StatusCreatedEventArgs : System.EventArgs
    {
        private int statusId;

        public int StatusId
        {
          get { return statusId; }
        }
        private string statusName;

        public string StatusName
        {
          get { return statusName; }
        }



        public StatusCreatedEventArgs(int statusId, string statusName)
        {
            this.statusId = statusId;
            this.statusName = statusName;
        }
    }
}
