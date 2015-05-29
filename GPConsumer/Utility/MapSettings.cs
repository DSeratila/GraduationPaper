using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPConsumer.Utility
{
    static class MapSettings
    {
        public static int CURRENT_LOCATION_ID = 1;

        static PointLatLng ourPosition = new PointLatLng(55.8198016524424, 37.3507690429688);
        int cc = 10;
        public static PointLatLng OurPosition
        {
            get { return MapSettings.ourPosition; }
            set { MapSettings.ourPosition = value; }
        }


        static PointLatLng defaultPosition = new PointLatLng(54.6961334816182, 25.2985095977783);
        public static PointLatLng DefaultPosition
        {
            get { return MapSettings.defaultPosition; }
        } 


        public static bool CorrectCoordinates()
        {
            if(ourPosition.Lat < -90 || ourPosition.Lat > 90 || ourPosition.Lng < -180 || ourPosition.Lng > 180)
                return false;
            return true;
        }
    }
}
