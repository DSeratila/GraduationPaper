using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GPConsumer.GPOrderServiceReference;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GPConsumer.Utility;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;

namespace GPConsumer.OtherForms
{
    public partial class DriverTrackForm : Form
    {
        internal readonly GMapOverlay objects = new GMapOverlay("objects");

        DriverDTO currentDriver;
        public DriverDTO CurrentDriver
        {
            get { return currentDriver; }
            set { currentDriver = value; }
        }

        public DriverTrackForm()
        {
            InitializeComponent();
        }

        private void DriverTrackForm_Load(object sender, EventArgs e)
        {
            this.map.MapProvider = GMapProviders.OpenStreetMap;
            map.MinZoom = 0;
            map.MaxZoom = 18;
            map.Zoom = 9;
            this.map.Overlays.Add(objects);
        }

        private void showTrackButton_Click(object sender, EventArgs e)
        {
            List<DriverStatisticsDTO> locations = new List<DriverStatisticsDTO>();
            objects.Markers.Clear();
            ServiceCallResult scr;
            scr = StatHelper.TryGetDriverStatisticsHistory(dateTimePicker1.Value, Properties.Settings.Default.radius, this.currentDriver.DriverId, locations);
            if (scr == ServiceCallResult.Success)
            {
                if (locations.Count == 0)
                {
                    MessageBox.Show("Перемещений курьера не заригистировано на данную дату");
                    return;
                }
                else
                {
                    int c = 1;
                    map.HoldInvalidation = true;
                    foreach (var v in locations)
                    {
                        GMapMarker position = new GMarkerGoogle(MapSettings.OurPosition, GMarkerGoogleType.black_small);
                        GMapMarker positionArrow = new GMarkerArrow(new PointLatLng());
                        position.IsVisible = true;
                        position.ToolTipMode = MarkerTooltipMode.Always;
                        position.ToolTipText = string.Format("{0}",c,v.LastUpdated.Value.TimeOfDay);
                        position.Position = new PointLatLng(v.Latitude, v.Longtitude);
                        
                        positionArrow.IsVisible = true;
                        positionArrow.ToolTipMode = MarkerTooltipMode.Always;
                        positionArrow.ToolTipText = string.Format("{0}",c,v.LastUpdated.Value.TimeOfDay);
                        positionArrow.Position = new PointLatLng(v.Latitude, v.Longtitude);
                        (positionArrow as GMarkerArrow).Bearing = (float)v.Bearing;
                        
                        c++;
                        
                        if(v.Bearing != 0)
                        {
                            objects.Markers.Add(positionArrow);
                        }
                        else
                        {
                          objects.Markers.Add(position);  
                        }
                        
                    }
                    map.ZoomAndCenterMarkers("objects");
                    map.Refresh();
                }
            }
            else
            { 
                MessageBox.Show("Ошибка при получении данных");
                    return;
            }
        }
    }
}
