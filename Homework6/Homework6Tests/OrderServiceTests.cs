using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork5.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        OrderService os = new OrderService();
        Goods pen = new Goods("8649-001", "钢笔", 25.8);
        Goods pencil = new Goods("8649-002", "铅笔", 2.5);
        Goods carbonPen = new Goods("8649-003", "碳素笔", 1.5);
        Goods ruler = new Goods("8650-001", "尺子", 5.0);
        Goods eraser = new Goods("8650-002", "橡皮", 1.5);
        Goods correctionTape = new Goods("8650-003", "涂改带", 10);

        Customer Sen = new Customer("森先生", "湖北省武汉市");
        Customer Yang = new Customer("杨小姐", "北京市");
        Customer Mike = new Customer("Mike", "Los Angeles");
        Customer ONo = new Customer("小野", "Tokyo");

        [TestInitialize]
        public void Initialize()
        {
            Order order1 = new Order(1, DateTime.Now, Sen);
            order1.AddItem(pen, 2);
            order1.AddItem(carbonPen, 10);
            order1.AddItem(ruler, 1);
            os.AddOrder(order1);

            Order order2 = new Order(2, DateTime.Now, ONo);
            order2.AddItem(pencil, 10);
            order2.AddItem(eraser, 5);
            order2.AddItem(ruler, 2);
            os.AddOrder(order2);

            Order order3 = new Order(3, DateTime.Now, Mike);
            order3.AddItem(carbonPen, 20);
            order3.AddItem(correctionTape, 3);
            os.AddOrder(order3);

            Order order4 = new Order(4, DateTime.Now, Sen);
            order4.AddItem(pen, 30);
            order4.AddItem(ruler, 20);
            order4.AddItem(pencil, 50);
            os.AddOrder(order4);
        }
        
        [TestCleanup]
        public void Cleanup()
        {
            for(int i = 0; i < os.myOrderList.ToArray().Length; i++)
            {
                os.myOrderList.Remove(os.myOrderList[i]);
            }
        }
        
        [TestMethod()] // 正常添加
        public void AddOrderTest()
        {
            Order order5 = new Order(5, DateTime.Now, Mike);
            order5.AddItem(pencil, 20);
            order5.AddItem(eraser, 10);
            order5.AddItem(ruler, 2);
            os.AddOrder(order5);
            Assert.AreEqual(os.FindOrder(5), order5);
        }
        [TestMethod()] // 添加重复编号订单
        [ExpectedException(typeof(Exception))]
        public void AddOrderTest2()
        {
            Order order5 = new Order(1, DateTime.Now, Mike);
            os.AddOrder(order5);
        }

        [TestMethod()] // 正常删除
        public void DeleteOrderTest()
        {
            os.DeleteOrder(2);
            Assert.IsNull(os.FindOrder(2));

            os.DeleteOrder("森先生");
            Assert.IsNull(os.FindOrder("森先生"));
        }
        [TestMethod()] // 删除不存在编号
        [ExpectedException(typeof(Exception))]
        public void DeleteOrderTest2()
        {
            os.DeleteOrder(5);
        }
        [TestMethod()] // 删除不存在客户
        [ExpectedException(typeof(Exception))]
        public void DeleteOrderTest3()
        {
            os.DeleteOrder("深蓝");
        }

        [TestMethod()] // 正常修改客户信息、订单明细
        public void UpdateOrderTest()
        {
            Customer Indigo = new Customer("深蓝", "北京市");
            os.UpdateOrder(3, Indigo);
            Order os2 = os.FindOrder(3);
            Assert.AreEqual(os2.customer, Indigo);

            List<OrderItem> oilist = new List<OrderItem>();
            OrderItem oi = new OrderItem(pen, 50);
            oilist.Add(oi);
            os.UpdateOrder(2, oilist);
            os2 = os.FindOrder(2);
            Assert.AreEqual(os2.orderList, oilist);
        }

        [TestMethod()] // 修改订单不存在
        [ExpectedException(typeof(Exception))]
        public void UpdateOrderTest1()
        {
            Customer Indigo = new Customer("深蓝", "北京市");
            os.UpdateOrder(5, Indigo);
        }

        [TestMethod()] // 正常通过订单号、姓名、货物名找订单
        public void FindOrderTest()
        {
            Assert.AreEqual(os.FindOrder(1),os.myOrderList[0]);

            List<Order> ol = new List<Order>();
            ol.Add(os.myOrderList[2]);
            Assert.AreEqual(os.FindOrder("Mike"), ol);

            ol.Clear();
            ol.Add(os.myOrderList[0]);ol.Add(os.myOrderList[2]);
            Assert.AreEqual(os.FindOrderByGoods("钢笔"), ol);
        }

        [TestMethod()] // 查找订单不存在
        public void FindOrderTest2()
        {
            Assert.IsNull(os.FindOrder(6));
            Assert.IsNull(os.FindOrder("董方"));
            Assert.IsNull(os.FindOrderByGoods("耳机"));

        }
        
        [TestMethod()]
        public void ExportTest()
        {
            os.Export("orderlist.xml");
            FileInfo fileInfo = new FileInfo("orderlist.xml");
            Assert.IsTrue(fileInfo.Exists);
        }

        [TestMethod()]
        public void ImportTest()
        {
            os.Export("orderlist.xml");
            OrderService os2 = new OrderService();
            os2.Import("orderlist.xml");
            Assert.AreEqual(os.myOrderList.ToArray().Length, os2.myOrderList.ToArray().Length);
            for (int i = 0; i < os.myOrderList.ToArray().Length; i++)
                Assert.AreEqual(os.myOrderList[i], os2.myOrderList[i]);
        }
    }
}