using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPConsumer.GPOrderServiceReference;
using System.ServiceModel;

namespace GPConsumer.Utility
{
    class VehicleHelper
    {
        public static ServiceCallResult TryGetAllVehicles(List<VehicleDTO> vehicles)
        {
            try
            {
                //List<VehicleDTO> result = new List<VehicleDTO>();

                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    foreach (var v in gpvc.GetAllVehicles())
                    {
                        vehicles.Add(v);
                    }
                   // vehicles = result;
                    return ServiceCallResult.Success;;
                }
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                //vehicles = null;
                return  ServiceCallResult.Error;
                //MessageBox.Show(ex.Message + "\nПовторите позже или обратитесь к администратору или разработчику программы");
            }
        }

        public static  ServiceCallResult TryAddVehicle(int driverId, string brand, string licencePlate, decimal length, decimal width, decimal height, decimal capacity, out VehicleDTO vehicle)
        {
            try
            {
                VehicleDTO result = new VehicleDTO();

                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    vehicle = gpvc.AddVehicle(driverId,brand,licencePlate,length,width,height,capacity);
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                vehicle = null;
                return ServiceCallResult.Error;
                //MessageBox.Show(ex.Message + "\nПовторите позже или обратитесь к администратору или разработчику программы");
            }
        }

        public static ServiceCallResult TryDeleteVehicle(int vehicleId)
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    gpvc.DeleteVehicle(vehicleId);
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
                //MessageBox.Show(ex.Message + "\nПовторите позже или обратитесь к администратору или разработчику программы");
            }
        }

        public static ServiceCallResult TryGetNewVehicles(List<VehicleDTO> v, out bool isNewVehiclesReceived)
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    List<VehicleDTO> newVehicles = new List<VehicleDTO>();

                    isNewVehiclesReceived = newVehicles.Count > 0 ? true : false;

                    foreach (var veh in newVehicles)
                    {
                        v.Add(veh);
                    }

                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                isNewVehiclesReceived = false;
                return ServiceCallResult.Error;
                //MessageBox.Show(ex.Message + "\nПовторите позже или обратитесь к администратору или разработчику программы");
            }
        }
    }
}
