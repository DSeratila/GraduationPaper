using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GPConsumer.GPOrderServiceReference;
using System.ServiceModel;

namespace GPConsumer.Utility
{
   public class StatHelper
    {
       public static ServiceCallResult TryGetOrderStatistics(List<OrderStatDTO> stats,int orderId)
       {
           try
           {
              
               using (GPOrderClient gpvc = new GPOrderClient())
               {
                   foreach (var o in gpvc.GetOrderStatistics(orderId))
                   {
                       stats.Add(o);
                   }
                   return ServiceCallResult.Success;
               }
           }
           catch (FaultException ex)
           {
               ExceptionLogger.WriteExceptionLog(ex.Message);
               //orders = null;
               return ServiceCallResult.Error;
               //MessageBox.Show(ex.Message + "\nПовторите позже или обратитесь к администратору или разработчику программы");
           }
       }

       public static ServiceCallResult TryGetDriverStatisticsHistory(DateTime dt, int radius, int driverId, List<DriverStatisticsDTO> stat)
       {
           try
           {

               using (GPOrderClient gpvc = new GPOrderClient())
               {
                   foreach (var o in gpvc.GetDriverStatisticsHistory(dt, radius,driverId))
                   {
                       stat.Add(o);
                   }
                   return ServiceCallResult.Success;
               }
           }
           catch (FaultException ex)
           {
               ExceptionLogger.WriteExceptionLog(ex.Message);
               //orders = null;
               return ServiceCallResult.Error;
               //MessageBox.Show(ex.Message + "\nПовторите позже или обратитесь к администратору или разработчику программы");
           }
       }
    }
}
