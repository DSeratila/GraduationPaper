using GPConsumer.GPOrderServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GPConsumer.Utility
{
    public class SecurityHelper
    {
        public static ServiceCallResult TryLogin(string userName, string password, out bool isLoginSuccessfull)
        {
            try
            {
                using (GPOrderClient gpdc = new GPOrderClient())
                {
                    isLoginSuccessfull = gpdc.Login(userName, password);
                    return ServiceCallResult.Success;
                }
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                isLoginSuccessfull = false;
                return ServiceCallResult.Error;
            }
        }
    }
}
