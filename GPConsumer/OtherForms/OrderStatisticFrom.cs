using GPConsumer.GPOrderServiceReference;
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
    public partial class OrderStatisticFrom : Form
    {
        List<OrderStatDTO> stat;

        public List<OrderStatDTO> Stat
        {
            get { return stat; }
            set { stat = value; }
        }

        public OrderStatisticFrom()
        {
            InitializeComponent();
        }

        private void OrderStatisticFrom_Load(object sender, EventArgs e)
        {
            orderStatDTOBindingSource.DataSource = stat;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
