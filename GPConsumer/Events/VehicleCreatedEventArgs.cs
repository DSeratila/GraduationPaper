using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPConsumer.Events
{
    public class VehicleCreatedEventArgs
    {
            private int createdVehicleId;

            public int CreatedVehicleId
            {
                get { return createdVehicleId; }
            }

            public VehicleCreatedEventArgs(int createdVehicleId)
            {
                this.createdVehicleId = createdVehicleId;
            }

    }
}
