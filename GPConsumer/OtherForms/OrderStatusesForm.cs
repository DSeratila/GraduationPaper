using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using GPConsumer.GPOrderServiceReference;
using GPConsumer.Events;
using GPConsumer.Utility;

namespace GPConsumer.OtherForms
{
    public partial class OrderStatusesForm : Form
    {

        public event StatusCreatedDelegate StatusCreated2;
        public event StatusDeletedDelegate StatusDeleted;

        List<OrderStatusDTO> statuses;

        public List<OrderStatusDTO> Statuses
        {
            get { return statuses; }
            set { statuses = value; }
        }

        public OrderStatusesForm()
        {
            InitializeComponent();
        }

        private void OrderStatusesForm_Load(object sender, EventArgs e)
        {
            if (this.Statuses.Count > 0)
            {
                listBox1.DataSource = statuses;
                listBox1.DisplayMember = "OrderStatusName";
            }
            else
            {
                MessageBox.Show("Статусов не найдено");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddingStatusForm asf = new AddingStatusForm();
            asf.StatusCreated += StatusCreated;
            asf.ShowDialog();

        }

        private void StatusCreated(object sender, GPConsumer.Events.StatusCreatedEventArgs e)
        {
            StatusCreated2(this, e);
            RefreshStatusesList();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            var status = (OrderStatusDTO)listBox1.SelectedItem;
            if (status != null)
            {
                ServiceCallResult scr;
                scr = OrderHelper.TryDeleteOrderStatus(status.OrderStatusId);
                if (scr == ServiceCallResult.Success)
                {
                    StatusDeleted(this, null);
                    RefreshStatusesList();
                }
            }
            else
            {
                MessageBox.Show("Выберите статус для удаления");
            }
        }

        private void RefreshStatusesList()
        {
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = statuses;
            listBox1.DisplayMember = "OrderStatusName";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
