using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

using GPConsumer.GPOrderServiceReference;


namespace GPConsumer.Utility
{
    static class VehicleLocationHelper
    {
        public static ServiceCallResult TryGetAllVehicleLocations(List<DriverCurrentLocationDTO> driverLocation)
        {
            try
            {
                using (GPOrderClient gpdc = new GPOrderClient())
                {
                    foreach (var d in gpdc.GetCurrentLocations())
                    {
                        DriverCurrentLocationDTO vcl = driverLocation.Where(v => v.DriverId == d.DriverId).FirstOrDefault();
                        if (vcl== null)
                        {
                            driverLocation.Add(d);
                        }
                        else
                        { 
                            vcl.Latitude = d.Latitude;
                            vcl.Longtitude = d.Longtitude;
                            vcl.DriverId = d.DriverId;
                            vcl.DriverName = d.DriverName;
                            vcl.LastUpdated = d.LastUpdated;
                        }
                    }
                }

                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }
        public static ServiceCallResult TryUpdateVehicleLocations(int driverId, double lat, double lng, TimeSpan time)
        {
            try
            {
                using (GPOrderClient gpdc = new GPOrderClient())
                {
                    gpdc.UpdateDriverLocation(driverId, lat, lng, time);
                }

                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }
        public static ServiceCallResult TryGetCurrentLocationsByDriverIdDate(int driverId, DateTime time, List<DriverCurrentLocationDTO> locations)
        {
            try
            {
                locations.Clear();
                using (GPOrderClient gpdc = new GPOrderClient())
                {

                    foreach (var vl in gpdc.GetCurrentLocationsByDriverIdDate(driverId, time).ToList())
                    {
                        locations.Add(vl);
                    } 
                }

                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }

    }
}
