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
    public partial class OrderEdit : Form
    {
        public Order CurrentOrder { get; set; }

        public OrderEdit()
        {
            InitializeComponent();
            customerBindingSource.Add(new Customer("0001", "Jack", "Beijing"));
            customerBindingSource.Add(new Customer("0002", "Mary", "Wuhan"));
        }

        public OrderEdit(Order order, bool editMode = false) : this()
        {
            CurrentOrder = order;
            orderBindingSource.DataSource = CurrentOrder;
            txtID.Enabled = !editMode;
            if (!editMode)
                CurrentOrder.customer = (Customer)customerBindingSource.Current;
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            OrderListEdit orderListEdit = new OrderListEdit(new OrderItem());
            try
            {
                if(orderListEdit.ShowDialog() == DialogResult.OK)
                {
                    int index = 0;
                    if (CurrentOrder.orderList.Count != 0)
                        index = CurrentOrder.orderList.Max(i => i.index) + 1;
                    orderListEdit.orderItem.index = index;
                    CurrentOrder.AddItem(orderListEdit.orderItem);
                    listBindingSource.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void btnSaveList_Click(object sender, EventArgs e)
        {
            //  这里还要加上订单合法性验证
            this.Close();
        }

        private void btnChangeList_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = listBindingSource.Current as OrderItem;
            if (orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            OrderListEdit orderListEdit = new OrderListEdit(orderItem);
            if (orderListEdit.ShowDialog() == DialogResult.OK)
            {
                listBindingSource.ResetBindings(false);
            }
        }

        private void btnDeleteList_Click(object sender, EventArgs e)
        {
            OrderItem orderItem = listBindingSource.Current as OrderItem;
            if(orderItem == null)
            {
                MessageBox.Show("请选择一个订单项进行删除");
                return;
            }
            CurrentOrder.DeleteItem(orderItem);
            listBindingSource.ResetBindings(false);
        }
    }
}
