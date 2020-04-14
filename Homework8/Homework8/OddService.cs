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
    public partial class Form1 : Form
    {
        OrderService orderService;
        BindingSource fieldsBS = new BindingSource();
        public String Keyword { get; set; }

        public Form1()
        {
            InitializeComponent();
            orderService = new OrderService();
            Order order1 = new Order(1, new Customer("0001", "Jack", "Beijing"), new List<OrderItem>());
            order1.AddItem(new OrderItem(1, new Goods("1", "苹果", 5.5), 20));
            orderService.AddOrder(order1); // 添加订单1
            Order order2 = new Order(2, new Customer("0002", "Mary", "Wuhan"), new List<OrderItem>());
            order2.AddItem(new OrderItem(1, new Goods("2", "梨", 8.5), 10));
            orderService.AddOrder(order2); // 添加订单2
            orderBindingSource.DataSource = orderService.myOrderList;
            comboBoxSel.SelectedIndex = 0;
            txtInput.DataBindings.Add("Text", this, "Keyword");
        }

        private void QueryAll()
        {
            orderBindingSource.DataSource = orderService.myOrderList;
            orderBindingSource.ResetBindings(false);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OrderEdit orderEdit = new OrderEdit(new Order());
            if (orderEdit.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(orderEdit.CurrentOrder);
                QueryAll();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            EditOrder();
        }

        private void dataGridViewOrder_DoubleClick(object sender, EventArgs e)
        {
            EditOrder();
        }

        private void EditOrder()
        {
            Order order = orderBindingSource.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            OrderEdit orderEdit = new OrderEdit(order, true);
            if (orderEdit.ShowDialog() == DialogResult.OK)
            {
                orderService.UpdateOrder(orderEdit.CurrentOrder);
                QueryAll();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Order order = orderBindingSource.Current as Order;
            if(order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            orderService.DeleteOrder(order.orderId);
            QueryAll();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                QueryAll();
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
        }

        private void buttonQuiry_Click(object sender, EventArgs e)
        {
            switch (comboBoxSel.SelectedIndex)
            {
                case 0: // 所有订单
                    orderBindingSource.DataSource = orderService.myOrderList;
                    break;
                case 1: // 根据ID查询
                    int.TryParse(Keyword, out int id);
                    Order order = orderService.FindOrder(id); // 转换成目标类型
                    List<Order> result = new List<Order>();
                    if (order != null) result.Add(order);
                    orderBindingSource.DataSource = result;
                    break;
                case 2: // 根据客户查询
                    orderBindingSource.DataSource = orderService.FindOrder(Keyword);
                    break;
                case 3: // 根据商品名查询
                    orderBindingSource.DataSource = orderService.FindOrderByGoods(Keyword);
                    break;
            }
            orderBindingSource.ResetBindings(true);
        }

    }
}
