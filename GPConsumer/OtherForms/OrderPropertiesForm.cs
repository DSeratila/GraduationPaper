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
using System.Threading;

namespace GPConsumer.OtherForms
{
    public partial class OrderPropertiesForm : Form
    {
        bool isMouseDown = false;
        readonly GMapOverlay top = new GMapOverlay();
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        internal readonly GMapOverlay polygons = new GMapOverlay("polygons");
        GMapMarker currentMarker;
        GMapMarker orderMarker;
        GMapMarker ourPositionMarker;
        GMapMarker fromMapMarker;
        GMapMarker driverPositionMarker;
        BackgroundWorker bgw;
        public enum OrderStatuses { NotFinished = 1, Finished = 2, Cancelled = 3 }
        OrderDTO orderToPopulate;

        public OrderDTO OrderToPopulate
        {
            set { orderToPopulate = value; }
        }

        List<DriverDTO> allDrivers;

        public List<DriverDTO> AllDrivers
        {
            set { allDrivers = value; }
        }

        DriverCurrentLocationDTO vehicleLocation;

        public DriverCurrentLocationDTO VehicleLocation
        {
            set { vehicleLocation = value; }
        }

        public OrderPropertiesForm()
        {
            InitializeComponent();
        }

        private void OrderPropertiesForm_Load(object sender, EventArgs e)
        {
            this.orderIdtextBox.Text = this.orderToPopulate.OrderId.ToString();
            if(this.orderToPopulate.CreatedDt!= null)
            {
                this.dateCreatedTimePicker.Value = (DateTime)this.orderToPopulate.CreatedDt;
            }
            else
            {
                dateCreatedTimePicker.Value = new DateTime(1900, 1, 1);
            }
            if (this.orderToPopulate.DeliveredDt != null)
            {
                this.textBox1.Text = this.orderToPopulate.CreatedDt.ToString();
            }
            else
            {
                this.textBox1.Text = "отсутствует";
            }
            this.customerNameTextBox.Text = this.orderToPopulate.CustomerName;
           
            if(this.orderToPopulate.DeliveryDriverId != null)
                driverNametextBox.Text = this.allDrivers.Where(d=> d.DriverId== this.orderToPopulate.DeliveryDriverId).First().DriverName;

            //driversComboBox.DisplayMember = "DriverName";
            //driversComboBox.ValueMember = "DriverId";
            //this.driversComboBox.SelectedIndex = this.driversComboBox.Items.IndexOf(allDrivers.Where(d=> d.DriverId == orderToPopulate.DeliveryDriverId).First());

            commentRichTextBox.Text = orderToPopulate.Comment;
            phoneTextBox.Text = orderToPopulate.Phone;
            totalTextBox.Text = orderToPopulate.TotalCost.ToString();
            lastUpdatedDateTimePicker.Value = orderToPopulate.LastUpdated;
            CityTextBox.Text = orderToPopulate.City;

            textBox2.Text = this.orderToPopulate.OrderStatusName;
            //statusComboBox.DataSource = Enum.GetValues(typeof(OrderStatuses));
            //statusComboBox.SelectedIndex = 0;

            SetMapInitialSettings();
            //orderSt .DataSource = Enum.GetValues(typeof(Status));
            //Status status;
            //Enum.TryParse<Status>(cbStatus.SelectedValue.ToString(), out status); 

            bgw = new BackgroundWorker();
            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += bgw_DoWork;
            bgw.ProgressChanged += bgw_ProgressChanged;
            
            if (!bgw.IsBusy)
            {
                bgw.RunWorkerAsync();
            }
       
        }

        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (driverPositionMarker != null)
            {
                map.HoldInvalidation = true;
                driverPositionMarker.Position = new PointLatLng(vehicleLocation.Latitude, vehicleLocation.Longtitude);
                map.Refresh();
            }
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bgw.CancellationPending)
            {
                bgw.ReportProgress(100);
                Thread.Sleep(Properties.Settings.Default.VehiclesUpdateRate* 1000);
            }
        }
        private void SetMapInitialSettings()
        {
            this.map.MapProvider = GMapProviders.OpenStreetMap;
            map.MinZoom = 0;
            map.MaxZoom = 18;
            map.Zoom = 9;
            this.map.Overlays.Add(objects);
            this.map.Overlays.Add(top);
            this.map.Overlays.Add(routes);

            map.Position = new PointLatLng(this.orderToPopulate.Latitude.GetValueOrDefault(), this.orderToPopulate.Longtitude.GetValueOrDefault());
            
            currentMarker = new GMarkerGoogle(map.Position, GMarkerGoogleType.arrow);
            currentMarker.IsHitTestVisible = false;
            map.Overlays.Add(objects);
            top.Markers.Add(currentMarker);

            orderMarker = new GMarkerGoogle(map.Position, GMarkerGoogleType.green_small);
            orderMarker.ToolTipMode = MarkerTooltipMode.Always;
            orderMarker.ToolTipText = string.Format("Заказ {0}\nКурьер: {1}\nСтатус: {2}", this.orderToPopulate.OrderId.ToString(), this.orderToPopulate.DeliveryDriverName, this.orderToPopulate.OrderStatusName);
            top.Markers.Add(orderMarker);

            ourPositionMarker = new GMarkerGoogle(MapSettings.OurPosition, GMarkerGoogleType.yellow_pushpin);
            ourPositionMarker.ToolTipMode = MarkerTooltipMode.Always;
            ourPositionMarker.ToolTipText = "Мы";
            objects.Markers.Add(ourPositionMarker);

            if (vehicleLocation != null)
            {
                driverPositionMarker = new GMarkerGoogle(MapHelper.GetPoint(vehicleLocation), GMarkerGoogleType.yellow_small);
                driverPositionMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                driverPositionMarker.ToolTipText = string.Format("{0};{1}", vehicleLocation.DriverName, vehicleLocation.LastUpdated.ToString());

                objects.Markers.Add(driverPositionMarker);
            }

            fromMapMarker = new GMarkerGoogle(MapSettings.OurPosition, GMarkerGoogleType.red_small);
            fromMapMarker.ToolTipMode = MarkerTooltipMode.Always;
            fromMapMarker.ToolTipText = "Отсюда";
            fromMapMarker.IsVisible = false;
            objects.Markers.Add(fromMapMarker);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void gMapControl3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;

                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = map.FromLocalToLatLng(e.X, e.Y);

                    var px = map.MapProvider.Projection.FromLatLngToPixel(currentMarker.Position.Lat, currentMarker.Position.Lng, (int)map.Zoom);
                    var tile = map.MapProvider.Projection.FromPixelToTileXY(px);
                }
            }
        }

        private void gMapControl3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fromOurPositionRadioButton.Checked)
            {
                routes.Clear();
                if (!MapSettings.CorrectCoordinates())
                {
                    MessageBox.Show("Текущее местоположение не задано. Задайте текущее местоположение");
                    SetInitialCoordinatesForm sicf = new SetInitialCoordinatesForm();
                    sicf.ShowDialog();
                }
                if (MapSettings.CorrectCoordinates())
                {
                    try
                    {
                        RoutingProvider rp = map.MapProvider as RoutingProvider;

                        MapRoute route = rp.GetRoute(ourPositionMarker.Position, orderMarker.Position, false, false, (int)map.Zoom);
                        if (route != null)
                        {
                            GMapRoute r = new GMapRoute(route.Points, route.Name);
                            r.IsHitTestVisible = true;
                            routes.Routes.Add(r);
                            string c = r.Distance.ToString("F2");
                            label9.Text = string.Format("Длина маршрута: {0} км.", c);
                            map.ZoomAndCenterRoute(r);
                        }
                        fromMapMarker.IsVisible = false;
                    }
                    catch (NullReferenceException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
                
            }
            if (fromMapRadioButton.Checked)
            {
                routes.Clear();
                RoutingProvider rp = map.MapProvider as RoutingProvider;
                MapRoute route = rp.GetRoute(currentMarker.Position, orderMarker.Position, false, false, (int)map.Zoom);
                fromMapMarker.Position = currentMarker.Position;
                fromMapMarker.IsVisible = true;
               
                if (route != null)
                {
                    GMapRoute r = new GMapRoute(route.Points, route.Name);
                    r.IsHitTestVisible = true;
                    routes.Routes.Add(r);
                    map.ZoomAndCenterRoute(r);
                    string c = r.Distance.ToString("F2");
                    label9.Text = string.Format("Длина маршрута: {0} км.", c);
                }
            }
            if (driverRadioButton.Checked)
            {
                if (driverPositionMarker == null)
                {
                    MessageBox.Show("У данного заказа нет курьера");
                    return;
                }
                fromMapMarker.IsVisible = false;
                routes.Clear();
                RoutingProvider rp = map.MapProvider as RoutingProvider;
                MapRoute route = rp.GetRoute(driverPositionMarker.Position, orderMarker.Position, false, false, (int)map.Zoom);
                if (route != null)
                {
                    GMapRoute r = new GMapRoute(route.Points, route.Name);
                    r.IsHitTestVisible = true;
                    routes.Routes.Add(r);
                    map.ZoomAndCenterRoute(r);
                    string c = r.Distance.ToString("F2");
                    label9.Text = string.Format("Длина маршрута: {0} км.", c);
                }
                
            }
        }

       
    }
}
