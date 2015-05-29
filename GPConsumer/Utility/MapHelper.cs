using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

using GPConsumer.GPOrderServiceReference;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.Device.Location;
using GMap.NET.MapProviders;

namespace GPConsumer.Utility
{
   static class MapHelper
    {
       public static void FillMarkersFromList(List<OrderDTO> orders, GMapOverlay overlay, int? currentDriverId)
       {
           overlay.Markers.Clear();   
           foreach (var o in orders)
           {           
               PointLatLng orderPosition = new PointLatLng(o.Latitude.GetValueOrDefault(), o.Longtitude.GetValueOrDefault());
               GMapMarker orderMarker = new GMarkerGoogle(orderPosition, GMarkerGoogleType.green_small);
               orderMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
               bool isVisible = currentDriverId == null ? true : o.DeliveryDriverId == currentDriverId ? true : false;
               orderMarker.IsVisible = isVisible;
               orderMarker.ToolTipText = string.Format("Заказ {0}\nКурьер: {1}\nСтатус: {2}", o.OrderId.ToString(),o.DeliveryDriverName, o.OrderStatusName);
               GPTag tag = new GPTag(o.OrderId, o.DeliveryDriverId);
               orderMarker.Tag = tag;
               

               overlay.Markers.Add(orderMarker);
           }
       }

       public static void FillMarkersFromList(List<DriverCurrentLocationDTO> vehiclesLocation, GMapOverlay overlay, int? currentDriverId)
        {
             overlay.Markers.Clear();

             foreach (var o in vehiclesLocation)
             {
                 PointLatLng orderPosition = new PointLatLng(o.Latitude, o.Longtitude);
                 GMapMarker orderMarker = new GMarkerGoogle(orderPosition, GMarkerGoogleType.orange_small);
                 orderMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                 bool isVisible = currentDriverId == null ? true : o.DriverId == currentDriverId ? true : false;
                 orderMarker.IsVisible = isVisible;
                 string strTime =  o.LastUpdated.ToString("T");
                 orderMarker.ToolTipText = string.Format("{0}; {1}", o.DriverName, strTime);
                 orderMarker.Tag = o.DriverId;

                 overlay.Markers.Add(orderMarker);
             }
        }

        public static void GetRoutes(PointLatLng initialPoint, List<OrderDTO> orders, GMapOverlay overlay, int zoom)
        {
            overlay.Routes.Clear();

            List<PointLatLng> finalRoutes = new List<PointLatLng>();
            //finalRoutes.Add(initialPoint);
            foreach (var o in orders)
            {
                finalRoutes.Add(new PointLatLng(o.Latitude.GetValueOrDefault(), o.Longtitude.GetValueOrDefault()));
            }

            PointComparer pc = new PointComparer();
            pc.z = initialPoint;
            
            finalRoutes.Sort(pc);

            PointLatLng current = initialPoint;
            RoutingProvider rp = GMapProviders.OpenStreetMap;

            foreach (var p in finalRoutes)
            {
               MapRoute route = rp.GetRoute(current, p, false, false, zoom);
              
               if (route != null)
               {
                   // add route
                   GMapRoute r = new GMapRoute(route.Points, route.Name);
                   overlay.Routes.Add(r);
                   current = p;
               }
            }

        }

       public static void ChangeOvelayMarkersVisibility(GMapOverlay o, bool isVisible)
       {
            foreach (var m in o.Markers)
	        {
                m.IsVisible = isVisible;
	        }
       }

       public static void DisplayCurrentDriverSituation(GMapOverlay couriersOverlay, GMapOverlay ordersOverlay, DriverCurrentLocationDTO driver)
       {
           //скрываем маркеры других тс, не принадлежащих данному vehicleLocation
           foreach (var m in couriersOverlay.Markers.Where(m=> (int)m.Tag!=driver.DriverId))
           {
               m.IsVisible = false;
           }
           //скрываем заказы других водителей
           foreach (var o in ordersOverlay.Markers.Where(o=> (int)o.Tag!=driver.DriverId))
           {
               o.IsVisible = false;
           }
       }

       public static void HideOrders(GMapOverlay ordersOverlay, int? driverId, bool displayAll)
       {
           //bool isVisible=false; 
           foreach (var o in ordersOverlay.Markers)
           {
               if (displayAll)
               {
                   o.IsVisible = true;
                   continue;
               }
               if (((GPTag)o.Tag).DriverId == driverId)
               {
                   o.IsVisible = true;
               }
               else
               {
                   o.IsVisible = false;
               }
               //if(driverId== null)
               //{
               //    isVisible = true;
               //}
               //else
               //{
               //    if (o.Tag == null)
               //    {
               //        isVisible = true;
               //    }
               //    else
               //    {
               //        isVisible = ((GPTag)o.Tag).DriverId == driverId ? true : false;
               //    }
               //}

               //o.IsVisible = isVisible;
               
           }
       }

       public static void HideVehicles(GMapOverlay vehiclesOverlay, int? driverId)
       {
           bool isVisible = false;
           foreach (var o in vehiclesOverlay.Markers)
           {
               if (driverId == null)
               {
                   isVisible = true;
               }
               else
               {
                   if (o.Tag == null)
                   {
                       isVisible = false;
                   }
                   else
                   {
                       isVisible = (int)o.Tag == driverId ? true : false;
                   }
               }

               o.IsVisible = isVisible;

           }
       }

       public static void ChangeOrderDriver(GMapOverlay overlay, int orderId, int? newDriver, int? oldDriver,bool displayAll)
       {
           GMapMarker g = overlay.Markers.Where(m => ((GPTag)m.Tag).OrderId == orderId).FirstOrDefault();
           ((GPTag)g.Tag).DriverId = newDriver;
           if (displayAll)
           {
               g.IsVisible = true;
           }
           else
           {
               g.IsVisible = false;
           }
       }

        class PointComparer : IComparer<PointLatLng>
        {
            public PointLatLng z;
            public int Compare(PointLatLng x, PointLatLng y)
            {
                GeoCoordinate x1 = new GeoCoordinate(x.Lat, x.Lng);
                GeoCoordinate y1 = new GeoCoordinate(y.Lat, y.Lng);
                GeoCoordinate z1 = new GeoCoordinate(z.Lat, z.Lng);

               double xDist = x1.GetDistanceTo(z1);
                double yDist = y1.GetDistanceTo(z1);


                if (xDist > yDist) return 1;
                else if (xDist < yDist) return -1;
                else return 0;
            }
        }

       public static PointLatLng GetPoint(DriverCurrentLocationDTO v)
       {
           return new PointLatLng(v.Latitude, v.Longtitude);
       }
       

    }
}
