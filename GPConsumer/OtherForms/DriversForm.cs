using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GPConsumer.Utility;
using GPConsumer.GPOrderServiceReference;
using GPConsumer.OtherForms;
using System.ServiceModel;
using GPConsumer.Events;

namespace GPConsumer.OtherForms
{
    /// <summary>
    /// Форма отображения водителей и действия над ними - добавление, удаление, и проч.
    /// </summary>
    public partial class DriversForm : Form
    {
        /// <summary>
        /// Отображаемые в форме водители
        /// </summary>
        List<DriverDTO> driversToPopulate;
         
        /// <summary>
        /// Текущий массив водителей. Ссылка передается из главной формы.
        /// </summary>
        public List<DriverDTO> DriversToPopulate
        {
            set { driversToPopulate = value; }
        }

        /// <summary>
        /// Отображаемые в форме водители
        /// </summary>
        List<VehicleDTO> vehiclesToPopulate;

        /// <summary>
        /// Текущий массив водителей. Ссылка передается из главной формы.
        /// </summary>
        public List<VehicleDTO> VehiclesToPopulate
        {
            set { vehiclesToPopulate = value; }
        }

        //public event DriverCreatedDelegate DriverCreatedDF;
        //public event DriverDeletedDelegate DriverDeletedDF;
        public event VehicleCreatedDelegate VehicleCreatedDF;

        public DriversForm()
        {
            InitializeComponent();
        }

        private void DriversFrom_Load(object sender, EventArgs e)
        {
            PopulateDrivers();
        }

        /// <summary>
        /// Переотображение водителей на форме. Приходится сбросить DataSouce для обновления отображения
        /// </summary>
        private void PopulateDrivers()
        {
            driversListBox.BeginUpdate();
            //заполняем listbox - отображение водителей
            driversListBox.DataSource = null;
            driversListBox.DataSource = this.driversToPopulate;
            driversListBox.DisplayMember = "DriverName";
            driversListBox.ValueMember = "DriverId";
            driversListBox.EndUpdate();
        }

        /// <summary>
        /// Обновление statusStrip, показывающего количество водителей
        /// </summary>
        private void driversListBox_DataSourceChanged(object sender, EventArgs e)
        {
            driversCountStatusStripLabel.Text = String.Format("Количество курьеров: {0}", this.driversToPopulate.Count);
        }

        /// <summary>
        /// Создание водителя
        /// </summary>
        private void createDriverButton_Click(object sender, EventArgs e)
        {
            DriverPropertiesForm dpf = new DriverPropertiesForm();
            dpf.AllDrivers = this.driversToPopulate;
            dpf.DriverCreatedDPF += dpf_DriverCreated;
            dpf.FormPurpose = FormPuproses.Create;
            dpf.ShowDialog();

        }
        /// <summary>
        /// Проброс события создания водителя и обработка отображения в текущей форме.
        /// Сначала обновляем массив, потом перезагружаем объекты в listBox.
        /// </summary>
        void dpf_DriverCreated(object sender, Events.DriverCreatedEventArgs e)
        {
            PopulateDrivers();
        }
        /// <summary>
        /// Редактирование водителя
        /// </summary>
        private void editDriverButton_Click(object sender, EventArgs e)
        {
            var driverToEdit = (DriverDTO)driversListBox.SelectedItem;
            if (driverToEdit == null)
            {
                MessageBox.Show("Нечего редактировать, куда ты клацаешь?", "Ошибка редактирования");
                return;
            }
            DriverPropertiesForm dpf = new DriverPropertiesForm();
            //dpf.DriverCreatedDPF += dpf_DriverCreated;
            dpf.FormPurpose = FormPuproses.Update;
            dpf.AllDrivers = driversToPopulate;
            dpf.DriverToEdit = driverToEdit;
            dpf.DriverUpdatedDPF += dpf_DriverUpdatedDPF;
            dpf.ShowDialog();
        }

        void dpf_DriverUpdatedDPF(object sender, EventArgs e)
        {
            PopulateDrivers();
        }

        private void deleteDriverButton_Click(object sender, EventArgs e)
        {
            ServiceCallResult scr;
            if ((DriverDTO)driversListBox.SelectedItem != null)
            {
                scr = DriverHelper.TryDeleteDriver(((DriverDTO)driversListBox.SelectedItem).DriverId);
                if (scr == ServiceCallResult.Success)
                {
                    this.driversToPopulate.Remove((DriverDTO)driversListBox.SelectedItem);
                    PopulateDrivers();
                }
                else
                {
                    MessageBox.Show("Ошибка при попытке удаления водителя");
                }
            }
            else
            {
                MessageBox.Show("Выберите водителя");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vehiclesButton_Click(object sender, EventArgs e)
        {
            if (this.driversListBox.SelectedItem != null)
            {
                //this.vehiclesToPopulate.Clear();
                //ServiceCallResult scr = VehicleHelper.TryGetAllVehicles(out this.vehiclesToPopulate);
                //if (scr == ServiceCallResult.Success)
                //{
                    DriverVehiclesForm dvf = new DriverVehiclesForm();
                    dvf.Driver = (DriverDTO)this.driversListBox.SelectedItem;
                    dvf.VehiclesToPopulate = this.vehiclesToPopulate;
                    dvf.VehicleCreatedDV += dvf_VehicleCreatedDV;
                    dvf.ShowDialog();
                //}
                //else 
                //{
                //    MessageBox.Show("Ошибка при попытке получения данных от сервиса");
                //}
            }
            else
            {
                MessageBox.Show("Водитель не выбран. Убедитесь, что вы выбрали водителя.", "Ошибка при попытке отображения транспорта");
            }

        }

        void dvf_VehicleCreatedDV(object sender, VehicleCreatedEventArgs e)
        {
            VehicleCreatedDF(this, e);
        }

        private void showDriverRouteButton_Click(object sender, EventArgs e)
        {
            DriverDTO driver = (DriverDTO)driversListBox.SelectedItem;
            if (driver != null)
            {
                DriverTrackForm dtf = new DriverTrackForm();
                dtf.CurrentDriver = driver;
                dtf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите водителя");
            }
        }

    }
}
