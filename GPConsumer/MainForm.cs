using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GPConsumer.OtherForms;
using GPConsumer.GPOrderServiceReference;
using GPConsumer.Utility;
using GPConsumer.Events;
using System.ServiceModel;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Diagnostics;
using System.Threading;

namespace GPConsumer
{
    public enum FormPuproses { Create, Update }
    public partial class MainForm : Form
    {
        #region Переменные
        /// <summary>
        /// Все водители
        /// </summary>
        List<DriverDTO> allDrivers;
        /// <summary>
        /// Все транспортные средства
        /// </summary>
        List<VehicleDTO> allVehicles;
        /// <summary>
        /// Все заказы
        /// </summary>
        List<OrderDTO> allOrders;
        /// <summary>
        /// Все координаты транспорта
        /// </summary>
        List<DriverCurrentLocationDTO> driverLocation;
        /// <summary>
        /// Список всех статусов заказа
        /// </summary>
        List<OrderStatusDTO> orderStatuses;
        /// <summary>
        /// Послупающие изменения
        /// </summary>
        List<string> changes;
        /// <summary>
        /// Первая ли это загрузка заказов
        /// </summary>
        bool isFirstLoad = true;
        /// <summary>
        /// Нужно при обработке прорисовки текущего маркера
        /// </summary>
        bool isMouseDown = false;
        /// <summary>
        /// Первая загрузка заказов
        /// </summary>
        bool isFirstOrdersLoad = true;

        bool isAllDisplayed = true;
        /// <summary>
        /// Оверлэй, содержащий текущее положение
        /// </summary>
        GMapOverlay topOverlay;
        /// <summary>
        /// Оверлэй заказов
        /// </summary>
        GMapOverlay ordersOverlay;
        /// <summary>
        /// Оверлэй текущего местоположения водителей
        /// </summary>
        GMapOverlay vehiclesLocationOverlay;
        /// <summary>
        /// Оверлэй маршрутов
        /// </summary>
        GMapOverlay routesOverlay;

        /// <summary>
        /// Маркет пооложения склада-магазина
        /// </summary>
        GMapMarker ourPosition;
        /// <summary>
        /// Маркер отображения клика по карте
        /// </summary>
        GMapMarker currentMarker;

        int? mapCurrentDriverId;

        bool isNewOrdersReceived = true;

        DriverDTO emptyDriver;
        const string emptyDriverName = "Без курьера";
        /// <summary>
        /// Воркет, обновляющий данные из дб - новые заказы и т.д.
        /// </summary>
        BackgroundWorker getNewOrdersBGW;
        BackgroundWorker getNewDictionariesBGW;
        BackgroundWorker getVehiclesLocation;
        #endregion
      
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            #region Инициалазация массивов
            this.allDrivers = new List<DriverDTO>();
            this.allVehicles = new List<VehicleDTO>();
            this.allOrders = new List<OrderDTO>();
            this.driverLocation = new List<DriverCurrentLocationDTO>();
            this.orderStatuses = new List<OrderStatusDTO>();
            this.changes = new List<string>();
            #endregion

            #region Инициализация переменных
            mapCurrentDriverId = null;
            emptyDriver = new DriverDTO();
            emptyDriver.DriverId = -1;
            emptyDriver.DriverName = emptyDriverName;

            ordersTimer = new System.Windows.Forms.Timer();
            ordersTimer.Interval = Properties.Settings.Default.OrdersUpdateRate * 1000;
            ordersTimer.Tick += ordersTimer_Tick;
            #endregion 

            #region Инициализация оверлеев
            this.topOverlay = new GMapOverlay();
            this.ordersOverlay = new GMapOverlay();
            this.vehiclesLocationOverlay = new GMapOverlay();
            this.routesOverlay = new GMapOverlay();
            
            topOverlay.IsVisibile = true;
            ordersOverlay.IsVisibile = ordersCheckBox.Checked;
            vehiclesLocationOverlay.IsVisibile = driversCheckBox.Checked;

            map.Overlays.Add(topOverlay);
            map.Overlays.Add(ordersOverlay);
            map.Overlays.Add(vehiclesLocationOverlay);
            map.Overlays.Add(routesOverlay);
            #endregion

            #region Задание стартовых настроек карты

            this.map.MapProvider = GMapProviders.OpenStreetMap;
            map.Position = MapSettings.DefaultPosition;
            map.MinZoom = 0;
            map.MaxZoom = 18;
            map.Zoom = 10;

            #endregion

            #region Добавление текущей позиции на карту и нашего местоположения
            //пытаемся загрузить наше местоположене
            
            ourPosition = new GMarkerGoogle(MapSettings.OurPosition, GMarkerGoogleType.yellow_pushpin);
            ourPosition.IsVisible = ourCheckBox.Checked;
            ourPosition.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            ourPosition.ToolTipText = "Мы";

            currentMarker = new GMarkerGoogle(map.Position, GMarkerGoogleType.arrow);
            currentMarker.IsHitTestVisible = false;
            currentMarker.Position = map.Position;

            topOverlay.Markers.Add(currentMarker);
            topOverlay.Markers.Add(ourPosition);

            #endregion 
            
            #region Инициализация BackGroundWorkerow
            //тот, что получает новые заказы
            getNewOrdersBGW = new BackgroundWorker();
            getNewOrdersBGW.WorkerSupportsCancellation = true;
            getNewOrdersBGW.WorkerReportsProgress = true;
            getNewOrdersBGW.DoWork += getNewOrdersBGW_DoWork;
            //getNewOrdersBGW.ProgressChanged += getNewOrdersBGW_ProgressChanged;
            getNewOrdersBGW.RunWorkerCompleted += getNewOrdersBGW_RunWorkerCompleted;
            
            //тот, что получает справочники(водители, ТС, и проч)
            getNewDictionariesBGW = new BackgroundWorker();
            getNewDictionariesBGW.WorkerSupportsCancellation = true;
            getNewDictionariesBGW.WorkerReportsProgress = true;
            getNewDictionariesBGW.ProgressChanged+=getNewDictionariesBGW_ProgressChanged;
            getNewDictionariesBGW.DoWork += getNewDictionariesBGW_DoWork;

            //тот, что получает данные о координатах водителей
            getVehiclesLocation = new BackgroundWorker();
            getVehiclesLocation.WorkerSupportsCancellation = true;
            getVehiclesLocation.WorkerReportsProgress = true;
            getVehiclesLocation.ProgressChanged += getVehiclesLocation_ProgressChanged;
            getVehiclesLocation.DoWork += getVehiclesLocation_DoWork;
            #endregion


        }

        #region фоновое обновление координат водителей
        void getVehiclesLocation_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!getVehiclesLocation.CancellationPending)
            {
                try
                {
                    //догружаем заказы из бд
                    lock (driverLocation)
                    {
                        VehicleLocationHelper.TryGetAllVehicleLocations(driverLocation);
                    } 

                    List<VehicleData> vd = new List<VehicleData>();
                    VilnusTransportDemo.GetVilniusTransportData(string.Empty, vd);
                    foreach (var i in vd)
                    {
                        VehicleLocationHelper.TryUpdateVehicleLocations(i.Id, i.Lat, i.Lng, new TimeSpan(1, 1, 1));
                    }
                    getVehiclesLocation.ReportProgress(100);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("updateFromDbBackGroundWorker: " + ex.ToString());
                }
                Thread.Sleep(Properties.Settings.Default.VehiclesUpdateRate * 1000);
            }
        }

        void getVehiclesLocation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
            map.HoldInvalidation = true;

            //richTextBox2.AppendText(DateTime.Now.ToString() + "\n");
            lock (driverLocation)
            {
                MapHelper.FillMarkersFromList(driverLocation, vehiclesLocationOverlay, this.mapCurrentDriverId);
            }
            
            map.Refresh();
        }
        #endregion

        #region фоновое обновление ТС, водителей и проч
        void getNewDictionariesBGW_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isNewVehicleReceived = false;
            bool isNewDriverReceived = false;
            while (!getNewDictionariesBGW.CancellationPending)
            {
                try
                {
                    lock (allVehicles)
                    {
                        VehicleHelper.TryGetNewVehicles(allVehicles, out isNewVehicleReceived);
                    }
                    lock (allDrivers)
                    {
                        DriverHelper.TryGetNewDrivers(allDrivers, out isNewDriverReceived);
                    }

                    if (isNewVehicleReceived || isNewDriverReceived)
                        getNewDictionariesBGW.ReportProgress(100);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("updateFromDbBackGroundWorker: " + ex.ToString());
                }
                Thread.Sleep(Properties.Settings.Default.DictionariesUpdateRate * 1000);
            }
        }

        private void getNewDictionariesBGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            getNewDictionariesBGW.CancelAsync();
        }
        #endregion

        #region Фоновое обновление поступающих закаов
        void ordersTimer_Tick(object sender, EventArgs e)
        {
            if (!getNewOrdersBGW.IsBusy)
                getNewOrdersBGW.RunWorkerAsync();
        }
        void getNewOrdersBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (isNewOrdersReceived || isFirstLoad)
            //{
                map.HoldInvalidation = true;
                lock (allOrders)
                {
                    MapHelper.FillMarkersFromList(allOrders, ordersOverlay, this.mapCurrentDriverId);
                }
                orderDTOBindingSource1.ResetBindings(false);
                isFirstOrdersLoad = false;
                map.Refresh();
            //}
        }
        void getNewOrdersBGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //while (!getNewOrdersBGW.CancellationPending)
            //{
                try
                {
                    //догружаем заказы из бд
                    lock (allOrders)
                    {
                        OrderHelper.TryGetNewOrders(allOrders, out isNewOrdersReceived, changes);
                    }

                    if (isNewOrdersReceived || isFirstOrdersLoad)
                        getNewOrdersBGW.ReportProgress(100);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("updateFromDbBackGroundWorker: " + ex.ToString());
                    throw;
                }
            //}
        }
        //void getNewOrdersBGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
           
        //}
        #endregion

        #region Первое соединение с базой(или после обрыва) По нажатию кнопки. Запуск BackgroundWorkero'ов
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // isFirstLoad = true;

            //Если загружаемся в первый раз - перезагружаем все массивы
            if (isFirstLoad)
            {
                #region Подгружаем данные из базы
                //очищаем массивы перед перезагрузкой из базы
                allDrivers.Clear();
                allVehicles.Clear();
                allDrivers.Clear();
                driverLocation.Clear();
                orderStatuses.Clear();

                //очищаем маркеры оверлеев(если вдруг потеряли коннект - надо отрисовать текущее положение всего) Текущее положение не чистим
                this.ordersOverlay.Markers.Clear();
                this.vehiclesLocationOverlay.Markers.Clear();
                this.routesOverlay.Markers.Clear();


                //Загрузаем заказы, водителей, справочник машин, текущие местоположения курьеров
                if (OrderHelper.TryGetAllOrders(this.allOrders) != ServiceCallResult.Success) 
                {
                    ShowConnectionWarning("Ошибка при загрузке заказов");
                    return;
                }
                this.allDrivers.Add(emptyDriver);

                if (DriverHelper.TryGetAllDrivers(this.allDrivers)!= ServiceCallResult.Success)
                {
                    ShowConnectionWarning("Ошибка при загрузке списка водителей");
                    return;
                }
                if (VehicleHelper.TryGetAllVehicles(this.allVehicles)!= ServiceCallResult.Success)
                {
                    ShowConnectionWarning("Ошибка при загрузке списка ТС");
                    return;
                }
                if (VehicleLocationHelper.TryGetAllVehicleLocations(this.driverLocation)!= ServiceCallResult.Success)
                {
                    ShowConnectionWarning("Ошибка при загрузке текущих местоположений курьеров");
                    return;
                }
                if (DictionaryHelper.TryGetOrderStatusesList(this.orderStatuses) != ServiceCallResult.Success)
                {
                    ShowConnectionWarning("Ошибка при загрузке списка статусов заказа");
                    return;
                }
                //загружаем текущее местоположение
                if (OrderHelper.TryGetOurLocation() != ServiceCallResult.Success)
                {
                    ShowConnectionWarning("Ошибка при загрузке списка статусов заказа");
                    return;
                }
                #endregion

                //Отображаем полученную из базы информацию
                PopulateLoadedInfo();

                //первая загрузка завершена

                if (!getNewOrdersBGW.IsBusy)
                {
                    getNewOrdersBGW.RunWorkerAsync();
                }

                isFirstLoad = false;
            }

            //данные загрузились, можно запускать фоновое обновление.
            if (!ordersTimer.Enabled)
            {
                ordersTimer.Start();
            }
            if (!getNewDictionariesBGW.IsBusy)
            {
                getNewDictionariesBGW.RunWorkerAsync();
            }
            if (!getVehiclesLocation.IsBusy)
            {
                getVehiclesLocation.RunWorkerAsync();
            }
        }

        private void ShowConnectionWarning(string s)
        {
            MessageBox.Show(s);
            this.isFirstLoad = true;
            return;
        }
        private void PopulateLoadedInfo()
        {
            //отображаем список курьеров
            driversComboBox.DataSource = allDrivers;
            driversComboBox.DisplayMember = "DriverName";
            driversComboBox.ValueMember = "DriverID";

            //отображаем в заказы в сетке
            ResetGrid();

            
            comboBox1.DataSource = allDrivers;
            comboBox1.DisplayMember = "DriverName";
            comboBox1.ValueMember = "DriverID";

            comboBox2.DataSource = orderStatuses;
            comboBox2.DisplayMember = "OrderStatusName";
            comboBox2.ValueMember = "OrderStatusId";

        }

        private void ResetGrid()
        {
            orderDTOBindingSource1.DataSource = allOrders;
            orderDTOBindingSource1.ResetBindings(false);
        }
        #endregion

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            DriversForm df = new DriversForm();
            df.DriversToPopulate = this.allDrivers;
            df.VehiclesToPopulate = this.allVehicles;
            df.VehicleCreatedDF += df_VehicleCreatedDF;
            df.ShowDialog();
        }

        void df_VehicleCreatedDF(object sender, VehicleCreatedEventArgs e)
        {
            // this.allVehicles.Add(DriverHelper.GetVehicle(e.CreatedVehicleId));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OrderPropertiesForm o = new OrderPropertiesForm();
            try
            {
                OrderDTO ordrToPopulate = (OrderDTO)ordersDataGridView.CurrentRow.DataBoundItem;
                o.OrderToPopulate = ordrToPopulate;
                o.AllDrivers = this.allDrivers;
                if (ordrToPopulate.DeliveryDriverId != null)
                    o.VehicleLocation = this.driverLocation.Where(v => v.DriverId == ordrToPopulate.DeliveryDriverId).FirstOrDefault();
                o.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ошибка");
            }

        }

        private void ordersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ordersOverlay.IsVisibile = ordersCheckBox.Checked;
        }

        private void ourCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!MapSettings.CorrectCoordinates())
            {
                MessageBox.Show("Текущее местоположение не задано. Задайте текущее местоположение");
                SetInitialCoordinatesForm sicf = new SetInitialCoordinatesForm();
                if (sicf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ourPosition.Position = MapSettings.OurPosition;
                    ourPosition.IsVisible = ourCheckBox.Checked;
                }
                else
                {
                    ourCheckBox.Checked = false;
                }
            }
            else
            {
                ourPosition.Position = MapSettings.OurPosition;
                ourPosition.IsVisible = ourCheckBox.Checked;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? driverId = ((DriverDTO)driversComboBox.SelectedItem).DriverId;
            driverId = driverId==-1?null:driverId;
            if (driverId == null)
            {
                MessageBox.Show("Курьер не выбран", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            this.mapCurrentDriverId = driverId;
            this.isAllDisplayed = false;
            MapHelper.HideOrders(ordersOverlay,this.mapCurrentDriverId, isAllDisplayed);
            MapHelper.HideVehicles(vehiclesLocationOverlay, this.mapCurrentDriverId);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.mapCurrentDriverId = null;
            this.isAllDisplayed = true;
            MapHelper.HideOrders(ordersOverlay, this.mapCurrentDriverId, isAllDisplayed);
            MapHelper.HideVehicles(vehiclesLocationOverlay, this.mapCurrentDriverId);
            this.routesOverlay.Routes.Clear();
        }

        private void driversCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            vehiclesLocationOverlay.IsVisibile = driversCheckBox.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int driverId = ((DriverDTO)driversComboBox.SelectedItem).DriverId;
            int? selectedDriverId = driverId == -1 ? (int?)null : driverId;
            List<OrderDTO> courierOrders = allOrders.Where(o => o.DeliveryDriverId == selectedDriverId).ToList();

            //строим маршрут от курьера
            if (couriteRadioButton.Checked)
            {
                //выбраны все курьеры
                if (selectedDriverId == null)
                {
                    MessageBox.Show("Курьер не выбран","Ошибка",MessageBoxButtons.OK);
                    return;
                }
                //если у курьера нет заказов
                if (courierOrders.Count == 0)
                {
                    MessageBox.Show("У курьера нет заказов", "Ошибка", MessageBoxButtons.OK);
                    return;
                }

                PointLatLng p = MapHelper.GetPoint(driverLocation.Where(v => v.DriverId == selectedDriverId).First());
                MapHelper.GetRoutes(p, courierOrders, routesOverlay, (int)map.Zoom);

            }
            //строим маршрут от текущего положения
            if (fromOurPositionRadioButton.Checked)
            {
                //помечаем наше местоположение на карте, ставим соотв. чекбокс
                this.ourCheckBox.Checked = true;
                //если текущее не задано, форсим пользователя задать текущее местоположение
                if (!MapSettings.CorrectCoordinates())
                {
                    MessageBox.Show("Текущее местоположение не задано. Задайте текущее местоположение");
                    SetInitialCoordinatesForm sicf = new SetInitialCoordinatesForm();
                    sicf.ShowDialog();
                }
                if (MapSettings.CorrectCoordinates())
                {
                    PointLatLng p = MapSettings.OurPosition;
                    MapHelper.GetRoutes(p, courierOrders, routesOverlay, (int)map.Zoom);
                }
                    //значит, он, гад такой, все-таки не задал текущее положение
                else
                {
                    MessageBox.Show("Координаты не заданы. Зайдите в настроки и задайте текущие координы");
                }
            }

            if (fromMapRadioButton.Checked)
            {
                PointLatLng p = currentMarker.Position;
                MapHelper.GetRoutes(p, courierOrders, routesOverlay, (int)map.Zoom);
            }
            

        }


        private void button5_Click(object sender, EventArgs e)
        {
            List<VehicleData> vd = new List<VehicleData>();
            VilnusTransportDemo.GetVilniusTransportData(string.Empty, vd);
        }

        private void ourPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetInitialCoordinatesForm sicf = new SetInitialCoordinatesForm();
            if (sicf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ourPosition.Position = MapSettings.OurPosition;
                ourPosition.IsVisible = ourCheckBox.Checked;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDTO o = (OrderDTO)ordersDataGridView.CurrentRow.DataBoundItem;
                DriverDTO d = (DriverDTO)comboBox1.SelectedItem;

                ServiceCallResult scr;
                scr = OrderHelper.TrySetOrderDeliveryCourierId(o.OrderId, d.DriverId);
                if (scr== ServiceCallResult.Success)
                {
                    OrderDTO ordr = allOrders.Where(or => or.OrderId == o.OrderId).FirstOrDefault();
                    int? previousDriverId = o.DeliveryDriverId;
                    if (d.DriverId == -1)
                    {
                        o.DeliveryDriverId = null;
                        o.DeliveryDriverName = null;
                        if (MessageBox.Show("Сменить статус на \"Принят в обработку\"?", "Смена статуса", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            if (OrderHelper.TrySetOrderStatus(o.OrderId, 1) == ServiceCallResult.Success)
                            {
                                o.OrderStatusId = 1;
                                o.OrderStatusName = "Принят в обработку";
                            }
                            else
                                MessageBox.Show("Ошибка смены статуса");
                        }
                       
                    }
                    else
                    {
                        o.DeliveryDriverId = d.DriverId;
                        o.DeliveryDriverName = d.DriverName;

                        if (MessageBox.Show("Сменить статус на \"Курьер назначен\"?", "Смена статуса", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            if (OrderHelper.TrySetOrderStatus(o.OrderId, 2) == ServiceCallResult.Success)
                            {
                                o.OrderStatusId = 2;
                                o.OrderStatusName = "Курьер назначен";
                            }
                            else
                                MessageBox.Show("Ошибка смены статуса");
                        }
                        //o.OrderStatusName = "Курьер назначен";
                        //o.OrderStatusId = 2;
                    }
                    MapHelper.ChangeOrderDriver(ordersOverlay, o.OrderId, o.DeliveryDriverId, previousDriverId, this.isAllDisplayed);
                }
               

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ошибка");
            }
           
        }

        void WriteLog(string logMessage)
        {
            //richTextBox1.AppendText(logMessage + '\n');
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OrderDTO currentOrder = (OrderDTO)ordersDataGridView.CurrentRow.DataBoundItem;
            OrderStatusDTO selectedStatus = (OrderStatusDTO)comboBox2.SelectedItem;
            int statusId = selectedStatus.OrderStatusId;

            int? currentStatusId = currentOrder.OrderStatusId;
            if (currentStatusId == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (statusId == currentStatusId)
                {
                    MessageBox.Show("Данный заказ и так уже в данном статусе");
                    return;
                }
                if (ServiceCallResult.Success == OrderHelper.TrySetOrderStatus(currentOrder.OrderId, selectedStatus.OrderStatusId))
                {
                    currentOrder.OrderStatusId = selectedStatus.OrderStatusId;
                    currentOrder.OrderStatusName = selectedStatus.OrderStatusName;
                }
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.routesOverlay.Routes.Clear();
        }

        private void map_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;

                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = map.FromLocalToLatLng(e.X, e.Y);

                    //var px = map.MapProvider.Projection.FromLatLngToPixel(currentMarker.Position.Lat, currentMarker.Position.Lng, (int)map.Zoom);
                    //var tile = map.MapProvider.Projection.FromPixelToTileXY(px);
                }
            }
        }

        private void map_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
             OrderDTO ordrToPopulate = (OrderDTO)ordersDataGridView.CurrentRow.DataBoundItem;
            List<OrderStatDTO> stat = new List<OrderStatDTO>();
            ServiceCallResult scr;

            if (ordrToPopulate != null)
            {
                scr = StatHelper.TryGetOrderStatistics(stat, ordrToPopulate.OrderId);
                if (scr == ServiceCallResult.Success&&stat.Count > 0)
                {
                    OrderStatisticFrom osf = new OrderStatisticFrom();
                    osf.Stat = stat;
                    osf.ShowDialog();
                }


            }
            else
                MessageBox.Show("Заказ не выбра6н", "Ошибка", MessageBoxButtons.OK);
        }

        private void статусыЗаказаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (orderStatuses.Count == 0)
            {
                MessageBox.Show("Статусов не найдено. Убедитесь, что соединение с сервером успешно");
                return;
            }
            OrderStatusesForm osf = new OrderStatusesForm();
            osf.Statuses = orderStatuses;
            osf.StatusCreated2 += osf_StatusCreated2;
            osf.StatusDeleted += osf_StatusDeleted;
            osf.ShowDialog();
        }

        void osf_StatusDeleted(object sender, StatusCreatedEventArgs e)
        {
            FullReloadStatuses();
        }

        void osf_StatusCreated2(object sender, StatusCreatedEventArgs e)
        {
            FullReloadStatuses();
        }

        private void FullReloadStatuses()
        {
            this.orderStatuses.Clear();
            DictionaryHelper.TryGetOrderStatusesList(this.orderStatuses);

            comboBox2.DataSource = null;
            comboBox2.DataSource = orderStatuses;
            comboBox2.DisplayMember = "OrderStatusName";
            comboBox2.ValueMember = "OrderStatusId";
        }

        private void button10_Click(object sender, EventArgs e)
        {
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            StatisticsForm sf = new StatisticsForm();
            sf.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
