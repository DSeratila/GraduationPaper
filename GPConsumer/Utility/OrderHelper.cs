using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GPConsumer.GPOrderServiceReference;
using System.ServiceModel;
using GMap.NET;

namespace GPConsumer.Utility
{
    static class OrderHelper
    {

        public static ServiceCallResult TryGetAllOrders(List<OrderDTO> orders)
        {
            try
            {
                //List<OrderDTO> result = new List<OrderDTO>();

                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    foreach (var o in gpvc.GetAllOrders())
                    {
                        orders.Add(o);
                    }
                    //orders = result;
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

        public static ServiceCallResult TryGetNewOrders(List<OrderDTO> orders, out bool isNewOrdersReceived, List<string> changes)
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    List<OrderDTO> newOrders = gpvc.GetNewOrders().ToList();

                    isNewOrdersReceived = newOrders.Count > 0 ? true : false; 

                    foreach (var o in newOrders)
                    {
                        OrderDTO old = orders.Where(or => or.OrderId == o.OrderId).FirstOrDefault();
                        if (old == null)
                        {
                            orders.Add(o);
                            string c = string.Format("{0}: заказ {1} добавлен", DateTime.Now.ToString(),o.OrderId.ToString());
                            changes.Add(c);
                        }
                        else
                        {
                            old.City = o.City;
                            old.Comment = o.Comment;
                            old.CreatedDt = o.CreatedDt;
                            old.CustomerName = o.CustomerName;
                            old.DeliveredDt = o.DeliveredDt;
                            old.DeliveryAdress = o.DeliveryAdress;
                            old.DeliveryDriverId = o.DeliveryDriverId;
                            old.DeliveryDriverName = o.DeliveryDriverName;
                            old.GoodsList = o.GoodsList;
                            old.IsDeleted = o.IsDeleted;
                            old.LastUpdated = o.LastUpdated;
                            old.Latitude = o.Latitude;
                            old.Longtitude = o.Longtitude;
                            old.OrderStatusId = o.OrderStatusId;
                            old.OrderStatusName = o.OrderStatusName;
                            old.Phone = o.Phone;
                            old.TotalCost = o.TotalCost;
                            old.UpdateDt = o.UpdateDt;

                            string c = string.Format("{0}: данные закаа {1} изменены", DateTime.Now.ToString(), o.OrderId.ToString());
                        }

                        
                    }
                    
                    return ServiceCallResult.Success; 
                }
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                isNewOrdersReceived = false;
                return ServiceCallResult.Error;
              
            }
        }

        public static ServiceCallResult TryGetOurLocation()
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    CurrentLocationDTO cl = gpvc.GetCurrentLocation(MapSettings.CURRENT_LOCATION_ID);
                    PointLatLng pos = new PointLatLng(cl.Latitude, cl.Longtitude);
                    MapSettings.OurPosition = pos;
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }

        public static ServiceCallResult TrySetOurLocation(PointLatLng p)
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    gpvc.SetCurrentLocation(MapSettings.CURRENT_LOCATION_ID, p.Lat, p.Lng);
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }

        public static ServiceCallResult TrySetOrderDeliveryCourierId(int orderId, int? deliveryDriverId)
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    if (deliveryDriverId == -1)
                    {
                        deliveryDriverId = null;
                    }
                    gpvc.SetOrderDeliveryDriverId(orderId, deliveryDriverId);
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }

        public static ServiceCallResult TrySetOrderStatus(int orderId, int statusId)
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    gpvc.UpdateOrderStatus(orderId, statusId);
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                return ServiceCallResult.Error;
            }
        }

        public static ServiceCallResult TryCreatOrderStatus(string name, out int? statusId)
        { 
              try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                    statusId = gpvc.CreateOrderStatus(name);
                }
                return ServiceCallResult.Success;
            }
            catch (FaultException ex)
            {
                ExceptionLogger.WriteExceptionLog(ex.Message);
                statusId = null;
                return ServiceCallResult.Error;
            }
        }

        public static ServiceCallResult TryDeleteOrderStatus(int statusId)
        {
            try
            {
                using (GPOrderClient gpvc = new GPOrderClient())
                {
                   gpvc.DeleteOrderStatus(statusId);
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
