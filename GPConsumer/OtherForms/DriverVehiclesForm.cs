using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GPConsumer.GPOrderServiceReference;
using GPConsumer.Events;
using GPConsumer.OtherForms;
using GPConsumer.Utility;

namespace GPConsumer.OtherForms
{
    public partial class DriverVehiclesForm : Form
    {
        public event VehicleCreatedDelegate VehicleCreatedDV;

        DriverDTO driver;

        /// <summary>
        /// Водитель, для которого отображаем транспорт
        /// </summary>
        public DriverDTO Driver
        {
            set { driver = value; }
        }

        List<VehicleDTO> vehiclesToPopulate;

        /// <summary>
        /// Отображаемый транспорт
        /// </summary>
        public List<VehicleDTO> VehiclesToPopulate
        {
            set { vehiclesToPopulate = value; }
        }

        FormPuproses formPurpose;

        public FormPuproses FormPurpose
        {
            get { return formPurpose; }
        }

      
        public DriverVehiclesForm()
        {
            InitializeComponent();
        }

        private void DriverVehiclesForm_Load(object sender, EventArgs e)
        {
            PopulateVehicles();
        }

        private void PopulateVehicles()
        {
            List<VehicleDTO> vehicles = this.vehiclesToPopulate.Where(v => v.DriverId == this.driver.DriverId).ToList();

            vehiclesListBox.BeginUpdate();
            vehiclesListBox.DataSource = null;
            vehiclesListBox.DataSource = vehicles;
            vehiclesListBox.ValueMember = "VehicleId";
            vehiclesListBox.EndUpdate();
            
        }

        private void vehiclesListBox_Format(object sender, ListControlConvertEventArgs e)
        {
             string brand = ((VehicleDTO)e.ListItem).Brand;
            string lp = ((VehicleDTO)e.ListItem).LicencePlate;
            e.Value = string.Format("Марка: {1}, Номерной знак: {1}", brand, lp);
        }

        private void vehiclesListBox_DataSourceChanged(object sender, EventArgs e)
        {
            driverNameLabel.Text = string.Format("ТС водителя {0}: ", this.driver.DriverName);
            vehicleCountStripStatusLabel.Text = string.Format("Количество транспортных средств курьера: {0}", this.vehiclesToPopulate.Count);
        }

        private void createVehicleButton_Click(object sender, EventArgs e)
        {
            VehiclePropertiesForm vpf = new VehiclePropertiesForm();
            vpf.VehicleToPopulate = (VehicleDTO)this.vehiclesListBox.SelectedItem;
            vpf.VehiclesToPopulate = vehiclesToPopulate;
            vpf.FormPurpose = FormPuproses.Create;
            vpf.Driver = this.driver;
            vpf.VehicleCreatedVP += vpf_VehicleCreatedVP;
            vpf.ShowDialog();
        }

        void vpf_VehicleCreatedVP(object sender, VehicleCreatedEventArgs e)
        {
            //VehicleCreatedDV(this, e);
            PopulateVehicles();
        }

        private void editVehicleButton_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void deleteVehicleButton_Click(object sender, EventArgs e)
        {
            ServiceCallResult scr;
            if ((VehicleDTO)vehiclesListBox.SelectedItem != null)
            {
                scr = VehicleHelper.TryDeleteVehicle(((VehicleDTO)vehiclesListBox.SelectedItem).VehicleId);
                if (scr == ServiceCallResult.Success)
                {
                    this.vehiclesToPopulate.Remove((VehicleDTO)vehiclesListBox.SelectedItem);
                    PopulateVehicles();
                }
                else
                {
                    MessageBox.Show("Ошибка при попытке удаления ТС");
                }
            }
            else
            {
                MessageBox.Show("Выберите ТС");
            }
        }
    }
}
