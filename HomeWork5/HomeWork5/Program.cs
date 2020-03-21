using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
/**
 * 写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单
 * （按照订单号、商品名称、客户等字段进行查询）功能。
 * 提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务）,
 * 订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
 * 要求：
 * （1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
 * （2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
 * （3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
 * （4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
 * （5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
 */

namespace HomeWork5
{
    class Order
    {
        public int orderId { get; set; }
        public DateTime orderTime { get; set; }
        public Customer customer { get; set; }
        public List<OrderItem> orderList { get; set; }

        public Order(int orderId, DateTime orderTime, Customer customer)
        {
            this.orderId = orderId;
            this.orderTime = orderTime;
            this.customer = customer;
            orderList = new List<OrderItem>();
        }

        public void AddItem(Goods goods, int quantity)
        {
            OrderItem oI = new OrderItem(goods, quantity);
            bool flag = true;
            foreach ( OrderItem s in orderList)      //若List中已存在该类货物，则认为数量叠加
            {
                if (s.Equals(oI))
                {
                    s.goodsQuantity += oI.goodsQuantity;
                    flag = false;
                    break;
                }
            }
            if(flag) orderList.Add(oI);   //否则添加新的订单明细
        }

        public double TotalPrise()
        {
            double sum = 0;
            foreach(OrderItem s in orderList)
            {
                sum += s.goodsTotalPrise();
            }
            return sum;
        }

        public override string ToString()
        {
            string str = "订单编号：" + orderId + "\n" +
                "下单时间：" + orderTime + "\n";
            str += "-----------------------------------\n";
            foreach(OrderItem oi in orderList)
            {
                str += oi;
            }
            str += "共    计：" + TotalPrise() + "\n";
            str += "-----------------------------------\n" +
                customer + "\n";
            str += "-----------------------------------\n";
            return str;
        }

        public override bool Equals(object obj)
        {
            Order m = obj as Order;
            return m != null && m.orderId == orderId;
        }
    }
    
    class OrderItem
    {
        public Goods goodsDetail { get; set; }
        public int goodsQuantity { get; set; }

        public double goodsTotalPrise()
        {
            return goodsDetail.perPrise * goodsQuantity;
        }

        public OrderItem(Goods goodsDetail, int goodsQuantity)
        {
            this.goodsDetail = goodsDetail;
            this.goodsQuantity = goodsQuantity;
        }

        public override string ToString()
        {
            return goodsDetail + "\n" + 
                "订购数目：" + goodsQuantity + "\t" +
                "\t" + goodsQuantity * goodsDetail.perPrise + "\n";
        }

        public override bool Equals(object obj)
        {
            OrderItem m = obj as OrderItem;
            return m != null && m.goodsDetail.id == goodsDetail.id;
        }
    }

    class OrderService
    {
        private List<Order> myOrderList { get; set; }
        public OrderService()
        {
            myOrderList = new List<Order>();
        }

        // 添加一个订单
        public void AddOrder(Order myOrder)
        {
            var order = from s in myOrderList
                        where s.orderId == myOrder.orderId
                        select s;
            if (!order.Any()) myOrderList.Add(myOrder);
            else throw new Exception("订单编号重复，添加失败");
        }

        
        // 删除订单
        // 通过订单id删除一个订单
        public void DeleteOrder(int id)
        {
            foreach(Order s in myOrderList)
            {
                if (s.orderId == id) myOrderList.Remove(s);
                if (s == myOrderList[myOrderList.ToArray().Length - 1] && s.orderId != id)
                    throw new Exception("不存在此订单编号，删除失败");
            }

        }

        // 删除一个人的所有订单
        public void DeleteCustomerOrder(string customer)
        {
            var order = from s in myOrderList
                        where s.customer.name == customer
                        select s;
            if (!order.Any()) throw new Exception("订单列表没有此客户的订单，删除失败");
            else
                foreach(Order s in myOrderList)
                    if (s.customer.name == customer) myOrderList.Remove(s);
        }


        // 修改订单
        // 修改客户信息
        public void UpdateOrder(int id, Customer newCustomer)
        {
            var order = from s in myOrderList
                        where s.orderId == id
                        select s;
            if (!order.Any()) throw new Exception("订单编号不存在，修改失败");
            else
                foreach (Order s in myOrderList)
                    if (s.orderId == id) s.customer = newCustomer;
        }

        // 修改订单明细
        public void UpdateOrder(int id, List<OrderItem> newOL)
        {
            var order = from s in myOrderList
                        where s.orderId == id
                        select s;
            if (!order.Any()) throw new Exception("订单编号不存在，修改失败");
            else
                foreach(Order s in myOrderList)
                    if(s.orderId == id)
                    {
                        int len = s.orderList.ToArray().Length;
                        for(int i = 0; i < len; i++)
                            s.orderList[i] = newOL[i];
                    }
        }


        // 查询订单
        // 通过ID查询订单
        public Order FindOrderById(int orderId)
        {
            var order = from s in myOrderList
                        where s.orderId == orderId
                        select s;
            Order od = new Order(order.First().orderId, order.First().orderTime, order.First().customer);
            Console.WriteLine(od);
            return od;
        }

        // 通过客户姓名查询此客户所有订单
        public List<Order> FindOrderByCustomer(string customerName)
        {
            var order = from s in myOrderList
                        where s.customer.name == customerName
                        orderby s.TotalPrise()
                        select s;
            List<Order> od = new List<Order>();
            od = order.ToList();
            foreach (var s in order)
                Console.WriteLine(s);
            return od;
        }

        // 通过商品名称查询包含此商品的所有订单
        public List<Order> FindOrderByGoods(string goodsName)
        {
            int len1 = myOrderList.ToArray().Length;
            List<Order> od = new List<Order>();
            for (int i = 0; i < len1; i++)
            {
                int len2 = myOrderList[i].orderList.ToArray().Length;
                for (int j = 0;j < len2; j++)
                    if (myOrderList[i].orderList[j].goodsDetail.name == goodsName)
                        od.Add(myOrderList[i]);
            }
            var query = from s in od
                        orderby s.TotalPrise()
                        select s;
            od = query.ToList();
            foreach (Order s in od)
                Console.WriteLine(s);
            return od;
        }
    }

    class Goods
    {
        public string id { get; set; }
        public string name { get; set; }
        public double perPrise { get; set; }

        public Goods(string id, string name, double perPrise)
        {
            this.id = id;
            this.name = name;
            this.perPrise = perPrise;
        }

        public override string ToString()
        {
            return "商品编号：" + id + "\n" +
                "商 品 名：" + name + "\n" +
                "商品单价：" + perPrise ;
        }
    }
    
    class Customer
    {
        public string name { get; set; }
        public string address { get; set; }

        public Customer(string name, string address)
        {
            this.address = address;
            this.name = name;
        }

        public override string ToString()
        {
            return "客户姓名：" + name + "\n" +
                "客户住址：" + address ;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //添加货物
            Goods pen = new Goods("8649-001", "钢笔", 25.8);
            Goods pencil = new Goods("8649-002", "铅笔", 2.5);
            Goods carbonPen = new Goods("8649-003", "碳素笔", 1.5);
            Goods ruler = new Goods("8650-001", "尺子", 5.0);
            Goods eraser = new Goods("8650-002", "橡皮", 1.5);
            Goods correctionTape = new Goods("8650-003", "涂改带", 10);
            //添加客户
            Customer Sen = new Customer("森先生", "湖北省武汉市");
            Customer Yang = new Customer("杨小姐", "北京市");
            Customer Mike = new Customer("Mike", "Los Angeles");
            Customer ONo = new Customer("小野", "Tokyo");

            //测试
            OrderService os = new OrderService();

            Order order1 = new Order(1, DateTime.Now, Sen);
            order1.AddItem(pen, 2);
            order1.AddItem(carbonPen, 10);
            order1.AddItem(ruler, 1);
            os.AddOrder(order1);   // 添加订单
            Thread.Sleep(683);

            Order order2 = new Order(2, DateTime.Now, ONo);
            order2.AddItem(pencil, 10);
            order2.AddItem(eraser, 5);
            order2.AddItem(ruler, 2);
            os.AddOrder(order2);   // 添加订单
            Thread.Sleep(566);

            Order order3 = new Order(3, DateTime.Now, Mike);
            order2.AddItem(carbonPen, 20);
            order2.AddItem(correctionTape, 3);
            os.AddOrder(order3);   // 添加订单
            Thread.Sleep(933);

            Console.WriteLine("--------查看所有订单--------");
            os.FindOrderById(1);
            os.FindOrderById(2);
            os.FindOrderById(3);
            Console.ReadLine();

        }
    }
}
