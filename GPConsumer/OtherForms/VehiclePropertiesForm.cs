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
using GPConsumer.Utility;

namespace GPConsumer.OtherForms
{
    public partial class VehiclePropertiesForm : Form
    {
        public event VehicleCreatedDelegate VehicleCreatedVP;

        VehicleDTO vehicleToPopulate;

        public VehicleDTO VehicleToPopulate
        {
            set { vehicleToPopulate = value; }
        }

        List<VehicleDTO> vehiclesToPopulate;

        public List<VehicleDTO> VehiclesToPopulate
        {
            set { vehiclesToPopulate = value; }
        }

        DriverDTO driver;
        public DriverDTO Driver
        {
            set { driver = value; }
        }
        FormPuproses formPurpose;

        public FormPuproses FormPurpose
        {
            set { formPurpose = value; }
        }

        public VehiclePropertiesForm()
        {
            InitializeComponent();
        }

        private void VehicleProperties_Load(object sender, EventArgs e)
        {
           //if(this.formPurpose= FormPuproses)
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            if (this.formPurpose == FormPuproses.Create && ValidateUserInput() && this.driver != null)
            {
                VehicleDTO createdVehicle = new VehicleDTO();
                decimal length = decimal.Parse(this.lengthTextBox.Text);
                decimal width = decimal.Parse(this.widthTextBox.Text);
                decimal height = decimal.Parse(this.heightTextBox.Text);
                decimal capacity = decimal.Parse(this.capacityTextBox.Text);

                ServiceCallResult scr;
                scr = VehicleHelper.TryAddVehicle(this.driver.DriverId, this.brandTextBox.Text, this.licenctPlateTextBox.Text, length, width, height, capacity, out createdVehicle);

                if (scr == ServiceCallResult.Success)
                {
                    vehiclesToPopulate.Add(createdVehicle);
                    VehicleCreatedVP(this, null);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения данных на сервере");
                }
               // VehicleDTO createdVehicle = VehicleHelper.TryAddDriver(this.driver.DriverId, this.brandTextBox.Text, this.licenctPlateTextBox.Text);
            }
            else
            {
                MessageBox.Show("Некорркетные данные");
            }

            //VehicleDTO v = new VehicleDTO();

            //v.Brand = brandTextBox.Text;
            //v.Capacity = decimal.Parse(capacityTextBox.Text);
            //v.DriverId = this.driver.DriverId;
            //v.Height = decimal.Parse(heightTextBox.Text);
            //v.Lenght = decimal.Parse(lengthTextBox.Text);
            //v.LicencePlate = licenctPlateTextBox.Text;
            //v.Width = decimal.Parse(widthTextBox.Text);

            //int newVehicleId = DriverHelper.AddVehicle(v);
            //VehicleCreatedEventArgs vcea = new VehicleCreatedEventArgs(newVehicleId);
            
            //VehicleCreatedVP(this, vcea);
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private bool ValidateUserInput()
        {
            return true;
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
