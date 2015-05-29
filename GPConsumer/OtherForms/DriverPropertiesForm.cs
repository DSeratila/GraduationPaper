using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GPConsumer.GPOrderServiceReference;
using GPConsumer.Utility;
using GPConsumer.Events;
using System.ServiceModel;
using System.Threading;

namespace GPConsumer.OtherForms
{
    
    public partial class DriverPropertiesForm : Form
    {
        public event DriverUpdatedDelegate DriverUpdatedDPF;
        public event DriverCreatedDelegate DriverCreatedDPF;

        FormPuproses formPurpose;

        internal FormPuproses FormPurpose
        {
            set { formPurpose = value; }
        }

        DriverDTO driverToEdit;
        public DriverDTO DriverToEdit
        {
            set { driverToEdit = value; }
        }

        List<DriverDTO> allDrivers;
        public List<DriverDTO> AllDrivers
        {
            set { allDrivers = value; }
        }
        public DriverPropertiesForm()
        {
            InitializeComponent();
        }
        private void DriverPropertiesForm_Load(object sender, EventArgs e)
        {
           // DriverDTO d = this.driverToEdit;
            if (this.driverToEdit != null && this.formPurpose == FormPuproses.Update)
            {
                this.nameTextBox.Text = this.driverToEdit.DriverName;
                this.phoneTextBox.Text = this.driverToEdit.PhoneNum;
                this.driverLicenctTextBox.Text = this.driverToEdit.LicenceNum;
                this.passportSeriesTextBox.Text = this.driverToEdit.PassportSeries;
                this.passportNumTexbox.Text = this.driverToEdit.PassportNum;
                this.passportGivenByTextBox.Text = this.driverToEdit.PassportGivenBy;
                this.passportGivenDateTimePicker.Value = DateTime.Now;
                this.passportGivenDivisionTextBox.Text = this.driverToEdit.PassportGivenDivision;
                this.emailTextBox.Text = this.driverToEdit.Email;
                this.notesRichTextBox.Text = this.driverToEdit.Notes;
            }
       

        }

        /// <summary>
        /// Сохранение водителя (либо нового, либо редактирование) Происходит вызов события DriverCreatedDPF
        /// </summary>
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            switch (this.formPurpose)
            {
                case FormPuproses.Create:
                    if (!ValidateUserInput())
                        return;
                    CreateNewDriver();
                    break;
                case FormPuproses.Update:
                    if (!ValidateUserInput())
                        return;
                    EditDriver();
                    break;
                default:
                    break;
            }
        }

        private bool ValidateUserInput()
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Проверьте ввод");
                this.nameTextBox.Focus();
                this.nameTextBox.SelectAll();
                return false;
            }

            return true;
        }

      
        private void CreateNewDriver()
        {
            DriverDTO createdDriver; 
            if (DriverHelper.TryAddDriver(nameTextBox.Text, emailTextBox.Text, driverLicenctTextBox.Text, notesRichTextBox.Text, passportGivenByTextBox.Text, passportGivenDateTimePicker.Value, passportGivenDivisionTextBox.Text, passportNumTexbox.Text, passportSeriesTextBox.Text, phoneTextBox.Text, out createdDriver)== ServiceCallResult.Success )
            {
                //добавляем водителя в коллекцию
                //allDrivers.Add(createdDriver);
                //Вызываем событие создания водителя для обновления данных в других формах
                //DriverCreatedDPF(this, null);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Проблемы при сохранении. Не сохранено");
            }
        }

        private void EditDriver()
        {
            //Изменяем водителя в бд и в массиве. Событие не требуется - он пришел к нам по ссылке. И так обновится
            if (this.driverToEdit != null)
            {

                ServiceCallResult scr = DriverHelper.TryUpdateDriver(this.driverToEdit.DriverId, nameTextBox.Text, emailTextBox.Text, driverLicenctTextBox.Text, notesRichTextBox.Text, passportGivenByTextBox.Text, passportGivenDateTimePicker.Value, passportGivenDivisionTextBox.Text, passportNumTexbox.Text, passportSeriesTextBox.Text, phoneTextBox.Text, ref this.driverToEdit);
                
                if (scr == ServiceCallResult.Success)
                {
                    int indx = allDrivers.IndexOf(this.driverToEdit);
                    //allDrivers[indx] = editedDriver;
                    //this.driverToEdit = editedDriver;
                    DriverUpdatedDPF(this, null);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Проблемы при редактировании. Изменения не сохранены");
                }
            }
        }

        /// <summary>
        /// Отмена сохранения или редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void declineButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

      
    }
}
