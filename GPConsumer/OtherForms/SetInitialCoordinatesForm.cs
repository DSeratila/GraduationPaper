using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GPConsumer.OtherForms;
using GPConsumer.Utility;
using GPConsumer.Events;
using System.ServiceModel;
using GPConsumer.GPOrderServiceReference;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET;

namespace GPConsumer.OtherForms
{
    public partial class SetInitialCoordinatesForm : Form
    {
        GMarkerGoogle currentMarker;
        bool isMouseDown = false;
        GMapOverlay top = new GMapOverlay();

        public SetInitialCoordinatesForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OrderHelper.TrySetOurLocation(currentMarker.Position);
            MapSettings.OurPosition = currentMarker.Position;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SetInitialCoordinatesForm_Load(object sender, EventArgs e)
        {
            map.MinZoom = 0;
            map.MaxZoom = 18;
            map.Zoom = 9;
            map.MapProvider = GMapProviders.OpenStreetMap;
            map.Position = MapSettings.DefaultPosition;
            currentMarker = new GMarkerGoogle(map.Position, GMarkerGoogleType.arrow);
            currentMarker.IsHitTestVisible = false;
            //map.Overlays.Add(objects);
            top.Markers.Add(currentMarker);
            map.Overlays.Add(top);

            ShowCoortinates(map.Position);
        }

        private void ShowCoortinates(PointLatLng p)
        {
            lngTextBox.Text = p.Lng.ToString();
            latTextBox.Text = p.Lat.ToString();
        }

        private void map_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void map_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;

                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = map.FromLocalToLatLng(e.X, e.Y);

                    var px = map.MapProvider.Projection.FromLatLngToPixel(currentMarker.Position.Lat, currentMarker.Position.Lng, (int)map.Zoom);
                    var tile = map.MapProvider.Projection.FromPixelToTileXY(px);
                    ShowCoortinates(currentMarker.Position);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
