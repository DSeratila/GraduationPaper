using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPConsumer.OtherForms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OrdersUpdateRate = (int)numericUpDown1.Value;
            Properties.Settings.Default.DictionariesUpdateRate = (int)numericUpDown2.Value;
            Properties.Settings.Default.radius = (int)numericUpDown4.Value;
            Properties.Settings.Default.VehiclesUpdateRate = (int)numericUpDown3.Value;
            Properties.Settings.Default.maxRows = (int)numericUpDown5.Value;
            Properties.Settings.Default.Save();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = Properties.Settings.Default.OrdersUpdateRate;
            numericUpDown2.Value = Properties.Settings.Default.DictionariesUpdateRate ;
            numericUpDown4.Value = Properties.Settings.Default.radius;
            numericUpDown3.Value = Properties.Settings.Default.VehiclesUpdateRate;
            numericUpDown5.Value = Properties.Settings.Default.maxRows;
        }
    }
}
