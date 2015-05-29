using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPConsumer.Events
{
    public delegate void DriverCreatedDelegate(object sender, DriverCreatedEventArgs e);
    public delegate void DriverUpdatedDelegate(object sender, EventArgs e);
    public delegate void DriverDeletedDelegate(object sender, DriverDeletedEventArgs e);
    public delegate void VehicleCreatedDelegate(object sender, VehicleCreatedEventArgs e);
    public delegate void StatusCreatedDelegate(object sender, StatusCreatedEventArgs e);
    public delegate void StatusDeletedDelegate(object sender, StatusCreatedEventArgs e);
}
