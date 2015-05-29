using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using GPLib.DTO;

namespace GPServices.OrdersService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrdersService" in both code and config file together.
    [ServiceContract]
    public interface IGPOrder
    {
        #region IGPOrder
        [OperationContract]
        OrderDTO AddOrder(int orderId, DateTime createdDt, string deliveryAdress, double latitude, double longtitude,
           string city, string comment, string customerName, string goodsList, string phone, decimal totalCost);
      
        [OperationContract]
        List<OrderDTO> GetAllOrders();

        [OperationContract]
        List<DriverCurrentLocationDTO> GetCurrentLocations();

       [OperationContract]
        CurrentLocationDTO GetCurrentLocation(int locationId);

       [OperationContract]
       void SetCurrentLocation(int locationId, double latitude, double longtitude);

       [OperationContract]
       List<OrderDTO> GetNewOrders();

       [OperationContract]
       void UpdateDriverLocation(int vehicleId, double lat, double lng, TimeSpan time);

       [OperationContract]
       List<OrderStatusDTO> GetOrderStatusesList();

       [OperationContract]
       void SetOrderDeliveryDriverId(int orderId, int? deliveryDriverId);

       [OperationContract]
       void UpdateOrderStatus(int orderId, int statusId);

       [OperationContract]
       List<DriverCurrentLocationDTO> GetCurrentLocationsByDriverIdDate(int driverId, DateTime date);

       [OperationContract]
       int? CreateOrderStatus(string name);

       [OperationContract]
        void DeleteOrderStatus(int orderStatusId);
        #endregion

        #region IGPDriver
       [OperationContract]
       DriverDTO AddDriver(string driverName, string email, string licenceNum, string notes, string passportGivenBy, DateTime passportGivenDate
            , string passportGivenDivision, string passportNum, string passportSeries, string phoneNum);

       [OperationContract]
       List<DriverDTO> GetAllDrivers();

       [OperationContract]
       DriverDTO UpdateDriver(int driverId, string driverName, string email, string licenceNum, string notes, string passportGivenBy, DateTime passportGivenDate
           , string passportGivenDivision, string passportNum, string passportSeries, string phoneNum);

       [OperationContract]
       void DeleteDriver(int driverId);

       [OperationContract]
       List<DriverDTO> GetNewDrivers();

        #endregion

        #region IGPVehicle
       [OperationContract]
       List<VehicleDTO> GetAllVehicles();

       [OperationContract]
       VehicleDTO AddVehicle(int driverId, string brand, string licencePlate, decimal length, decimal width, decimal height, decimal capacity);

       [OperationContract]
       void DeleteVehicle(int vehicleId);

       [OperationContract]
       List<VehicleDTO> GetNewVehicles();
        #endregion

        #region Statistics
        [OperationContract]
       List<OrderStatDTO> GetOrderStatistics(int order_id);

        [OperationContract]
        List<DriverStatisticsDTO> GetDriverStatisticsHistory(DateTime dt, int radius, int driverId);
        #endregion

        [OperationContract]
        bool Login(string userName, string password);

        [OperationContract]
        void Test();
    }
}
