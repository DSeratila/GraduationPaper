using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GPServices.OrdersService;
using GPLib;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using GPLib.DTO;

namespace GPServices.OrdersService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrdersService" in both code and config file together.
    public class GPOrder : IGPOrder
    {
        #region Тексты ошибок
        const string ENTITY_EXCEPTION_EM = "Сервис доступен, но попытка получения данных от БД не удалась. Источник ошибки: {0}. Сервис: {1}. Метод: {2} Внутренняя ошибка: {3}";
        const string VALIDATION_EXCEPTION_EM = "Ошибка при валидации данных (при попытке сохраниния в БД). Проверьте длины строк и убедитесь в их соответствии. Источник ошибки: {0}. Сервис: {1}. Метод: {2} Внутренняя ошибка: {3}";
        const string DB_UPDATE_EXCEPRION_EM = "Ошибка при попытке сохранения данных. Возможны нарушения ограничений. Источник ошибки: {0}. Сервис: {1}. Метод: {2} Внутренняя ошибка: {3}";
        const string SERVICE_NAME = "GPOrder";
        #endregion

        #region Заказы
        public OrderDTO AddOrder(int orderId, DateTime createdDt, string deliveryAdress, double latitude, double longtitude,
            string city, string comment, string customerName, string goodsList, string phone, decimal totalCost)
        {
            string methodName = "AddOrder";
            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    Order newOrder = new Order();
                    newOrder.DeliveryDriverId = null;
                    newOrder.OrderId = orderId;
                    newOrder.CreatedDt = createdDt;
                    newOrder.DeliveredDt = null;
                    newOrder.DeliveryAdress = deliveryAdress;
                    newOrder.Latitude = latitude;
                    newOrder.Longtitude = longtitude;
                    newOrder.City = city;
                    newOrder.Comment = comment;
                    newOrder.CustomerName = customerName;
                    newOrder.GoodsList = goodsList;
                    newOrder.Phone = phone;
                    newOrder.TotalCost = totalCost;
                    newOrder.LastUpdated = DateTime.Now;
                    newOrder.IsDeleted = false;
                    newOrder.OrderStatusId = 1;
                    newOrder.IsRead = false;
                    gpe.Orders.Add(newOrder);
                    gpe.SaveChanges();
                }
                using (GPEntities gpe = new GPEntities())
                {
                    Order createdOrdr = gpe.Orders.Where(o => o.OrderId == orderId).Single();
                    return CreateDTOOrder(createdOrdr);
                }

            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }


        public List<OrderDTO> GetAllOrders()
        {
            string methodName = "GetAllOrders";
            try
            {
                List<OrderDTO> allOrders = new List<OrderDTO>();

                using (GPEntities gpe = new GPEntities())
                {
                   
                    foreach (var o in gpe.Orders.Where(ordr=> ordr.IsDeleted == false))
                    {
                        allOrders.Add(CreateDTOOrder(o));
                        o.IsRead = true;
                    }
                    gpe.SaveChanges();
                }
                return allOrders;

            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }


        public List<OrderDTO> GetNewOrders()
        {
            string methodName = "GetNewOrders";
            try
            {
                List<OrderDTO> allOrders = new List<OrderDTO>();

                using (GPEntities gpe = new GPEntities())
                {

                    foreach (var o in gpe.Orders.Where(ordr=> ordr.IsRead== false))
                    {
                        allOrders.Add(CreateDTOOrder(o));
                        o.IsRead = true;
                    }
                    gpe.SaveChanges();
                }
                return allOrders;

            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }
     
       public List<DriverCurrentLocationDTO> GetCurrentLocations()
        {
            string methodName = "GetCurrentLocations";
            List<DriverCurrentLocationDTO> result = new List<DriverCurrentLocationDTO>();

            try
            {
                using(GPEntities gpe = new GPEntities())
                {
                     foreach (var cvl in gpe.DriverCurrentLocations)
                    {
                        result.Add(CreateDTOVehicleLocation(cvl));
                    }
                }

                return result;
            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }

       public CurrentLocationDTO GetCurrentLocation(int locationId)
       {
           string methodName = "GetCurrentLocation";
           CurrentLocationDTO ourLocation = new CurrentLocationDTO();
           try
           {
               using (GPEntities gpe = new GPEntities())
               {
                   CurrentLocation cl = gpe.CurrentLocations.Where(c => c.LocationId == locationId).Single();
                   ourLocation.LastUpdated = cl.LastUpdated;
                   ourLocation.Latitude = cl.Latitude;
                   ourLocation.LocationId = cl.LocationId;
                   ourLocation.Longtitude = cl.Longtitude;
                 
               }

               return ourLocation;
           }
           #region Исключения
           catch (EntityException ex)
           {
               throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbEntityValidationException ex)
           {
               throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbUpdateException ex)
           {
               throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           #endregion
       }

       public void SetCurrentLocation(int locationId, double latitude, double longtitude)
       {
           string methodName = "SetCurrentLocation";
           try
           {
               using (GPEntities gpe = new GPEntities())
               {
                   CurrentLocation cl = gpe.CurrentLocations.Where(c => c.LocationId == locationId).Single();
                   cl.Latitude = latitude;
                   cl.Longtitude = longtitude;
                   cl.LastUpdated = DateTime.Now;
                   gpe.SaveChanges();
               }

           }
           catch (EntityException ex)
           {
               throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbEntityValidationException ex)
           {
               throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbUpdateException ex)
           {
               throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
       }

       public void UpdateDriverLocation(int driverId, double lat, double lng, TimeSpan time)
       {
           string methodName = "UpdateDriverLocation";
           try
           {
               using (GPEntities gpe = new GPEntities())
               {
                   DriverCurrentLocation cl = gpe.DriverCurrentLocations.Where(c => c.DriverId == driverId).FirstOrDefault();
                   if (cl == null)
                       return;
                       
                   cl.Latitude = lat;
                   cl.Longtitude = lng;
                   cl.LastUpdated = DateTime.Now;
                   gpe.SaveChanges();

                   DriverLocation vl = new DriverLocation();
                   vl.DriverId = cl.DriverId;
                   vl.IsDeleted = false;
                   vl.LastUpdated = DateTime.Now;
                   vl.Latitude = cl.Latitude;
                   vl.Longtitude = cl.Longtitude;

                   gpe.DriverLocations.Add(vl);
                   gpe.SaveChanges();

               }

           }
           catch (EntityException ex)
           {
               throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbEntityValidationException ex)
           {
               throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbUpdateException ex)
           {
               throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
            
       }

       public List<OrderStatusDTO> GetOrderStatusesList()
       {
           string methodName = "GetOrderStatusesList";
           try
           {
               List<OrderStatusDTO> statusList = new List<OrderStatusDTO>();
               using (GPEntities gpe = new GPEntities())
               {
                   foreach (var os in gpe.OrderStatus.Where(o => o.IsDeleted == false)) 
                   {
                       OrderStatusDTO osdto = new OrderStatusDTO();
                       osdto.OrderStatusId = os.OrderStatusId;
                       osdto.OrderStatusName = os.OrderStatusName;
                       statusList.Add(osdto);
                   }
               }
               return statusList;

           }
           catch (EntityException ex)
           {
               throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbEntityValidationException ex)
           {
               throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbUpdateException ex)
           {
               throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
       }
      public void SetOrderDeliveryDriverId(int orderId, int? deliveryDriverId)
       {
           string methodName = "SetOrderDeliveryDriverId";
           try
           {
               using (GPEntities gpe = new GPEntities())
               {
                   Order o = gpe.Orders.Where(ordr => ordr.OrderId == orderId).FirstOrDefault();
                   if (o != null)
                   {
                       o.DeliveryDriverId = deliveryDriverId;
                       gpe.SaveChanges();
                       OrderCourierChanx occ = new OrderCourierChanx();
                       occ.DeliveryDriverId = o.DeliveryDriverId;
                       occ.OrderId = o.OrderId;
                       occ.LastUpdated = DateTime.Now;
                       

                       gpe.OrderCourierChanges.Add(occ);
                       gpe.SaveChanges();
                   }
               }
              

           }
           catch (EntityException ex)
           {
               throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbEntityValidationException ex)
           {
               throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
           catch (DbUpdateException ex)
           {
               throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
           }
       }

      public void UpdateOrderStatus(int orderId, int statusId)
      {
          string methodName = "UpdateOrderStatus";
          try
          {
              using (GPEntities gpe = new GPEntities())
              {
                  Order o = gpe.Orders.Where(ordr => ordr.OrderId == orderId).FirstOrDefault();
                  if (o != null)
                  {
                      o.OrderStatusId = statusId;
                      OrderStatusChanx osc = new OrderStatusChanx();
                      osc.IsDeleted = false;
                      osc.IsRead = false;
                      osc.OrderId = o.OrderId;
                      osc.OrderStatusId = statusId;
                      osc.LastUpdated = DateTime.Now;
                      gpe.OrderStatusChanges.Add(osc);
                      gpe.SaveChanges();
                  }
              }

          }
          catch (EntityException ex)
          {
              throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
          catch (DbEntityValidationException ex)
          {
              throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
          catch (DbUpdateException ex)
          {
              throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
      }
      

      public int? CreateOrderStatus(string name)
      {
          string methodName = "CreateOrderStatus";

          try
          {
              using (GPEntities gpe = new GPEntities())
              {
                  OrderStatu os = gpe.OrderStatus.Where(s => s.OrderStatusName == name).FirstOrDefault();
                  if (os != null)
                      return null;

                  OrderStatu newStatus = new OrderStatu();
                  newStatus.OrderStatusName = name;
                  newStatus.IsDeleted = false;
                  newStatus.LastUpdatedDt = DateTime.Now;
                  gpe.OrderStatus.Add(newStatus);
                  gpe.SaveChanges();
                  return newStatus.OrderStatusId;
              }
          }
          catch (EntityException ex)
          {
              throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
          catch (DbEntityValidationException ex)
          {
              throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
          catch (DbUpdateException ex)
          {
              throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
      }

     public void DeleteOrderStatus(int orderStatusId)
      {
          string methodName = "DeleteOrderStatus";

          try
          {
              using (GPEntities gpe = new GPEntities())
              {
                  OrderStatu os = gpe.OrderStatus.Where(s => s.OrderStatusId == orderStatusId).FirstOrDefault();
                  if (os == null)
                      return; 
                  
                  os.IsDeleted = true;
                  os.LastUpdatedDt = DateTime.Now;
                  gpe.SaveChanges();
              }
          }
          catch (EntityException ex)
          {
              throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
          catch (DbEntityValidationException ex)
          {
              throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
          catch (DbUpdateException ex)
          {
              throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
      }

        private OrderDTO CreateDTOOrder(Order o)
        {
            OrderDTO ordr = new OrderDTO();
            ordr.DeliveryDriverId = o.DeliveryDriverId;
            ordr.City = o.City;
            ordr.Comment = o.Comment;
            ordr.CreatedDt = o.CreatedDt;
            ordr.CustomerName = o.CustomerName;
            ordr.DeliveredDt = o.DeliveredDt;
            ordr.DeliveryAdress = o.DeliveryAdress;
            ordr.DeliveryDriverId = o.DeliveryDriverId;
            ordr.GoodsList = o.GoodsList;
            ordr.IsDeleted = o.IsDeleted;
            ordr.LastUpdated = o.LastUpdated;
            ordr.Latitude = o.Latitude;
            ordr.Longtitude = o.Longtitude;
            ordr.OrderId = o.OrderId;
            ordr.OrderStatusId = o.OrderStatusId;
            ordr.Phone = o.Phone;
            ordr.TotalCost = o.TotalCost;
            ordr.DeliveryDriverName = o.Driver==null? null:o.Driver.DriverName;
            ordr.OrderStatusName = o.OrderStatu.OrderStatusName;

            return ordr;
        }

        #region DTO help методы
        private DriverCurrentLocationDTO CreateDTOVehicleLocation(DriverCurrentLocation v)
        {
            DriverCurrentLocationDTO driverLocation = new DriverCurrentLocationDTO();
            driverLocation.DriverId = v.DriverId;
            driverLocation.DriverName = v.Driver.DriverName;
            driverLocation.LastUpdated = v.LastUpdated;
            driverLocation.Latitude = v.Latitude;
            driverLocation.Longtitude = v.Longtitude;
            return driverLocation;
        }

        private DriverCurrentLocationDTO CreateDTOVehicleLocation(DriverLocation v)
        {
            DriverCurrentLocationDTO driverLocation = new DriverCurrentLocationDTO();
            driverLocation.DriverId = v.DriverId;
            driverLocation.LastUpdated = v.LastUpdated;
            driverLocation.Latitude = v.Latitude;
            driverLocation.Longtitude = v.Longtitude;

            return driverLocation;
        }
        #endregion
        
        #endregion

        #region бывший GPDriver
        public DriverDTO AddDriver(string driverName, string email, string licenceNum, string notes, string passportGivenBy, DateTime passportGivenDate
           , string passportGivenDivision, string passportNum, string passportSeries, string phoneNum)
        {
            string methodName = "AddDriver";
            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    Driver newDriver = new Driver();
                    newDriver.DriverName = driverName;
                    newDriver.Email = email;
                    newDriver.LicenceNum = licenceNum;
                    newDriver.Notes = notes;
                    newDriver.PassportGivenBy = passportGivenBy;
                    newDriver.PassportGivenDate = passportGivenDate;
                    newDriver.PassportGivenDivision = passportGivenDivision;
                    newDriver.PassportNum = passportNum;
                    newDriver.PassportSeries = passportSeries;
                    newDriver.PhoneNum = phoneNum;
                    newDriver.LastUpdated = DateTime.Now;
                    newDriver.IsDeleted = false;

                    gpe.Drivers.Add(newDriver);
                    gpe.SaveChanges();

                    return CreateDTODriver(newDriver);
                }

            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }

        }


        public List<DriverDTO> GetAllDrivers()
        {
            string methodName = "GetAllDrivers";
            try
            {
                // получаем список водителей из базы, инкапсулируем их в DriverDTO
                using (GPEntities gpe = new GPEntities())
                {
                    List<DriverDTO> allDrivers = new List<DriverDTO>();

                    foreach (var d in gpe.Drivers.Where(d => d.IsDeleted == false))
                    {
                        DriverDTO driver = CreateDTODriver(d);

                        allDrivers.Add(driver);
                    }
                    return allDrivers;
                }
            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }

        }

        public DriverDTO UpdateDriver(int driverId, string driverName, string email, string licenceNum, string notes, string passportGivenBy, DateTime passportGivenDate
            , string passportGivenDivision, string passportNum, string passportSeries, string phoneNum)
        {
            string methodName = "UpdateDriver";

            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    Driver d = gpe.Drivers.Where(s => s.DriverId == driverId).First();
                    d.DriverName = driverName;
                    d.Email = email;
                    d.LicenceNum = licenceNum;
                    d.Notes = notes;
                    d.PassportGivenBy = passportGivenBy;
                    d.PassportGivenDate = passportGivenDate;
                    d.PassportGivenDivision = passportGivenDivision;
                    d.PassportNum = passportNum;
                    d.PassportSeries = passportSeries;
                    d.PhoneNum = phoneNum;
                    d.LastUpdated = DateTime.Now;

                    gpe.SaveChanges();
                    return CreateDTODriver(d);
                }
            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }

        }

        public void DeleteDriver(int driverId)
        {
            string methodName = "DeleteDriver";

            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    Driver d = gpe.Drivers.Where(s => s.DriverId == driverId).First();
                    d.IsDeleted = true;
                    d.LastUpdated = DateTime.Now;
                    gpe.SaveChanges();
                }
            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }

        }

        public List<DriverDTO> GetNewDrivers()
        {
            string methodName = "GetNewDrivers";
            try
            {
                // получаем список водителей из базы, инкапсулируем их в DriverDTO
                using (GPEntities gpe = new GPEntities())
                {
                    List<DriverDTO> allDrivers = new List<DriverDTO>();

                    foreach (var d in gpe.Drivers.Where(d => d.IsDeleted == false && d.IsRead == false))
                    {
                        DriverDTO driver = CreateDTODriver(d);
                        allDrivers.Add(driver);
                        d.IsRead = true;
                    }
                    gpe.SaveChanges();
                    return allDrivers;
                }
            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }

        }

        /// <summary>
        /// Создание DTO обертки для водителя. Просто чтобы упростить код.
        /// </summary>
        private static DriverDTO CreateDTODriver(Driver d)
        {
            DriverDTO driver = new DriverDTO();

            driver.DriverId = d.DriverId;
            driver.DriverName = d.DriverName;
            driver.Email = d.Email;
            driver.LicenceNum = d.LicenceNum;
            driver.Notes = d.Notes;
            driver.PassportGivenBy = d.PassportGivenBy;
            driver.PassportGivenDate = d.PassportGivenDate;
            driver.PassportGivenDivision = d.PassportGivenDivision;
            driver.PassportNum = d.PassportNum;
            driver.PassportSeries = d.PassportSeries;
            driver.PhoneNum = d.PhoneNum;
            return driver;
        }
        #endregion

        #region бывший Vehicle
        public List<VehicleDTO> GetAllVehicles()
        {
            string methodName = "GetAllVehicles";
            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    List<VehicleDTO> allVehicles = new List<VehicleDTO>();
                    foreach (var v in gpe.Vehicles.Where(v => v.IsDeleted == false && v.Driver.IsDeleted == false))
                    {
                        allVehicles.Add(CreateDTOVehicle(v));
                    }

                    return allVehicles;
                }
            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }

        }

        public VehicleDTO AddVehicle(int driverId, string brand, string licencePlate, decimal length, decimal width, decimal height, decimal capacity)
        {
            string methodName = "AddVehicle";
            try
            {
                int vehicleId = -1;
                Vehicle v = CreateVehicleFromParts(driverId, brand, licencePlate, length, width, height, capacity);
                using (GPEntities gpe = new GPEntities())
                {
                    gpe.Vehicles.Add(v);
                    gpe.SaveChanges();
                    vehicleId = v.VehicleId;
                }
                using (GPEntities gpe = new GPEntities())
                {
                    Vehicle createdVehicle = gpe.Vehicles.Where(v2 => v2.VehicleId == vehicleId).Single();
                    return CreateDTOVehicle(createdVehicle);
                }

            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            string methodName = "DeleteVehicle";

            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    Vehicle vehicleToDelete = gpe.Vehicles.Where(v => v.VehicleId == vehicleId).First();
                    vehicleToDelete.IsDeleted = true;
                    vehicleToDelete.LastUpdated = DateTime.Now;
                    gpe.SaveChanges();
                }
            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }

        public List<VehicleDTO> GetNewVehicles()
        {
            string methodName = "GetNewVehicles";

            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    List<VehicleDTO> allVehicles = new List<VehicleDTO>();
                    foreach (var v in gpe.Vehicles.Where(v => v.IsDeleted == false && v.Driver.IsDeleted == false && v.IsRead == false))
                    {
                        allVehicles.Add(CreateDTOVehicle(v));
                        v.IsRead = true;
                    }
                    gpe.SaveChanges();

                    return allVehicles;
                }
            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }

        private static VehicleDTO CreateDTOVehicle(Vehicle v)
        {
            VehicleDTO newVehichle = new VehicleDTO();
            newVehichle.Brand = v.Brand;
            newVehichle.Capacity = v.Capacity;
            newVehichle.DriverId = v.DriverId;
            newVehichle.Height = v.Height;
            newVehichle.Lenght = v.Length;
            newVehichle.LicencePlate = v.LicencePlate;
            newVehichle.VehicleId = v.VehicleId;
            newVehichle.Width = v.Width;
            newVehichle.VehicleName = string.Format("Vehicle {0} LP: {1}", v.Brand, v.LicencePlate);

            return newVehichle;
        }
        private static Vehicle CreateVehicleFromDTO(VehicleDTO v)
        {
            Vehicle newVehicle = new Vehicle();
            newVehicle.Brand = v.Brand;
            newVehicle.Capacity = v.Capacity;
            newVehicle.DriverId = v.DriverId;
            newVehicle.Height = v.Height;
            newVehicle.IsDeleted = false;
            newVehicle.Length = v.Lenght;
            newVehicle.LicencePlate = v.LicencePlate;
            newVehicle.Width = v.Width;
            newVehicle.LastUpdated = DateTime.Now;

            return newVehicle;
        }

        private static Vehicle CreateVehicleFromParts(int driverId, string brand, string licencePlate, decimal length, decimal width, decimal height, decimal capacity)
        {
            Vehicle newVehicle = new Vehicle();
            newVehicle.DriverId = driverId;
            newVehicle.Brand = brand;
            newVehicle.LicencePlate = licencePlate;
            newVehicle.Length = length;
            newVehicle.Width = width;
            newVehicle.Height = height;
            newVehicle.Capacity = capacity;
            newVehicle.LastUpdated = DateTime.Now;

            newVehicle.IsDeleted = false;

            return newVehicle;
        }
        #endregion

        #region Статистика

        public List<DriverCurrentLocationDTO> GetCurrentLocationsByDriverIdDate(int driverId, DateTime date)
      {
          string methodName = "GetCurrentLocationsByDriverIdDate";
          List<DriverCurrentLocationDTO> result = new List<DriverCurrentLocationDTO>();

          try
          {
              using (GPEntities gpe = new GPEntities())
              {
                  DateTime dt2 = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).Add(new TimeSpan(24, 0, 0));
                  foreach (var cvl in gpe.DriverLocations.Where(c=> c.DriverId==driverId && c.LastUpdated >= date && c.LastUpdated < dt2))
                  {
                      result.Add(CreateDTOVehicleLocation(cvl));
                  }
              }

              return result;
          }
          catch (EntityException ex)
          {
              throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
          catch (DbEntityValidationException ex)
          {
              throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
          catch (DbUpdateException ex)
          {
              throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
          }
      }

        public List<OrderStatDTO> GetOrderStatistics(int order_id)
        {
            string methodName = "GetOrderStatistics";
            try
            {
                List<OrderStatDTO> o = new List<OrderStatDTO>();
                using (GPEntities gpe = new GPEntities())
                {
                    var stat = gpe.OrderStatistics_Get2(order_id);
                    foreach (var s in stat)
                    {
                        OrderStatDTO oStat = new OrderStatDTO();
                        oStat.OrderId = s.OrderId;
                        oStat.dt = s.dt;
                        oStat.descr = s.descr;
                        o.Add(oStat);
                    }
                    return o;
                }
              

            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }

        public List<DriverStatisticsDTO> GetDriverStatisticsHistory(DateTime dt, int radius, int driverId)
        {
            string methodName = "GetDriverStatisticsHistory";
            try
            {
                List<DriverStatisticsDTO> result = new List<DriverStatisticsDTO>();
                using (GPEntities gpe = new GPEntities())
                {
                    string date = dt.Date.ToString("d");
                    foreach (var dtg in gpe.DriverTrackList_Get(date, radius, driverId))
                    {
                        DriverStatisticsDTO ds = new DriverStatisticsDTO();
                        ds.Bearing = dtg.Bearing;
                        ds.Distance = dtg.Distance;
                        ds.DriverId = dtg.DriverId;
                        ds.LastUpdated = dtg.LastUpdated;
                        ds.Latitude = dtg.Latitude;
                        ds.Longtitude = dtg.Longtitude;
                        ds.RowId = dtg.RowId;

                        result.Add(ds);
                    }
                    return result;
                }

            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }

        #endregion 

        public bool Login(string userName, string password)
        {
            string methodName = "Login";
            try
            {
                using (GPEntities gpe = new GPEntities())
                {
                    var stat = gpe.GPUsers.Where(u=> u.UserName == userName && u.UserPassword == password).FirstOrDefault();
                    if (stat == null)
                        return false;
                    return true;

                }


            }
            catch (EntityException ex)
            {
                throw new FaultException(string.Format(ENTITY_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbEntityValidationException ex)
            {
                throw new FaultException(string.Format(VALIDATION_EXCEPTION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
            catch (DbUpdateException ex)
            {
                throw new FaultException(string.Format(DB_UPDATE_EXCEPRION_EM, ex.Source, SERVICE_NAME, methodName, ex.Message));
            }
        }

        public void Test()
        {
        //    using (GPEntities e = new GPEntities())
        //    {
             
        //    }
        }
    }
}
