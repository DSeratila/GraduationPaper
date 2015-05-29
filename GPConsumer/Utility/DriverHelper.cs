using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPConsumer.GPOrderServiceReference;
using System.ServiceModel;

namespace GPConsumer.Utility
{
    public enum ServiceCallResult {Success, Error}

    static class DriverHelper
    {
        public static ServiceCallResult TryGetAllDrivers(List<DriverDTO> drivers )
        {
            try
            {
                using (GPOrderClient gpdc = new GPOrderClient())
                {
                    foreach (var d in gpdc.GetAllDrivers())
                    {
                        drivers.Add(d);
                    }
                    return ServiceCallResult.Success;
                }
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }

        public static ServiceCallResult TryAddDriver(string driverName,string email, string licenceNum, string notes,string passportGivenBy, DateTime passportGivenDate
            , string passportGivenDivision, string passportNum, string passportSeries, string phoneNum, out DriverDTO driver)
        {
            try
            {
                using (GPOrderClient gpdc = new GPOrderClient())
                {
                    driver = gpdc.AddDriver(driverName, email, licenceNum, notes, passportGivenBy, passportGivenDate
                        , passportGivenDivision, passportNum, passportSeries, phoneNum);
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                driver = null;
                return ServiceCallResult.Error;
            }
        }

        public static  ServiceCallResult TryUpdateDriver(int driverId, string driverName, string email, string licenceNum, string notes, string passportGivenBy, DateTime passportGivenDate
            , string passportGivenDivision, string passportNum, string passportSeries, string phoneNum, ref DriverDTO driver)
        {
            try
            {
                using (GPOrderClient gpdc = new GPOrderClient())
                {
                    DriverDTO ud = gpdc.UpdateDriver(driverId, driverName, email, licenceNum, notes, passportGivenBy, passportGivenDate
                        , passportGivenDivision, passportNum, passportSeries, phoneNum);
                    driver.DriverId = ud.DriverId;
                    driver.DriverName = ud.DriverName;
                    driver.Email = ud.Email;
                    driver.LicenceNum = ud.LicenceNum;
                    driver.Notes = ud.Notes;
                    driver.PassportGivenBy = ud.PassportGivenBy;
                    driver.PassportGivenDate = ud.PassportGivenDate;
                    driver.PassportGivenDivision = ud.PassportGivenDivision;
                    driver.PassportNum = ud.PassportNum;
                    driver.PassportSeries = ud.PassportSeries;
                    driver.PhoneNum = ud.PhoneNum;
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }

        public static ServiceCallResult TryDeleteDriver(int driverId)
        {
            try
            {
                using (GPOrderClient gpdc = new GPOrderClient())
                {
                    gpdc.DeleteDriver(driverId);
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }

        public static ServiceCallResult TryGetNewDrivers(List<DriverDTO> drivers, out bool isNewDriverReceived)
        {
            isNewDriverReceived = false;
            try
            {
                using (GPOrderClient gpdc = new GPOrderClient())
                {
                    List<DriverDTO> newDrivers = gpdc.GetNewDrivers().ToList();
                    isNewDriverReceived = newDrivers.Count > 0 ? true : false;

                    foreach (var d in newDrivers)
                    {
                        drivers.Add(d);
                    }
                    return ServiceCallResult.Success;
                }
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                isNewDriverReceived = false;
                return ServiceCallResult.Error;
            }
        }
    }
}
