using OrderServiceAPP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework8
{
    public partial class OrderListEdit : Form
    {
        public OrderItem orderItem { get; set; }
        public OrderListEdit()
        {
            InitializeComponent();
        }

        public OrderListEdit(OrderItem orderItem)
        {
            this.orderItem = orderItem;
            this.itemBindingSource.DataSource = orderItem;
            goodsBindingSource.Add(new Goods("1", "苹果", 5.5));
            goodsBindingSource.Add(new Goods("2", "梨", 8.5));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemBindingSource.ResetBindings(false);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
