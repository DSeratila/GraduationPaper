using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GPConsumer.Utility;
using GPConsumer.Events;

namespace GPConsumer.OtherForms
{
    public partial class AddingStatusForm : Form
    {
        public event StatusCreatedDelegate StatusCreated;
        public AddingStatusForm()
        {
            InitializeComponent();
        }

        private void AddingStatusForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите имя статуса");
                return;
            }
            ServiceCallResult scr;
            int? createdStatusId = null;
           scr = OrderHelper.TryCreatOrderStatus(textBox1.Text, out createdStatusId);
           if (scr == ServiceCallResult.Success)
           {
               if (createdStatusId == null)
               {
                   MessageBox.Show("Такой статус уже существует");
                   return;
               }
               
               var stcr = new StatusCreatedEventArgs((int)createdStatusId,textBox1.Text);
               StatusCreated(this, stcr);
               this.DialogResult = System.Windows.Forms.DialogResult.OK;

           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
