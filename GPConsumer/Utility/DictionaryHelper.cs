using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPConsumer.GPOrderServiceReference;
using System.ServiceModel;

namespace GPConsumer.Utility
{
    class DictionaryHelper
    {
        public static ServiceCallResult TryGetOrderStatusesList(List<OrderStatusDTO> statuses)
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    foreach (var o in gpvc.GetOrderStatusesList())
                    {
                        statuses.Add(o);
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
    }
}
