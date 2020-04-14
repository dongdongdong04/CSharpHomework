using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace OrderServiceAPP
{
    public class OrderService
    {
        public List<Order> myOrderList { get; set; }

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
            else throw new ApplicationException("订单编号重复，添加失败");
        }

        // 删除订单
        // 通过订单id删除一个订单
        public void DeleteOrder(int id)
        {
            var order = from s in myOrderList
                        where s.orderId == id
                        select s;
            if (order.Any()) myOrderList.Remove(order.First());
            else throw new Exception("不存在此订单编号，删除失败");
        }

        // 删除一个人的所有订单
        public void DeleteOrder(string Customer)
        {
            var order = from s in myOrderList
                        where s.customer.name == Customer
                        select s;
            if (order.Any()) myOrderList = myOrderList.Where(x => x.customer.name != Customer).ToList();
            else throw new Exception("订单列表没有此客户的订单，删除失败");
        }

        // 修改订单
        public void UpdateOrder(Order order)
        {
            Order oldOrder = FindOrder(order.orderId);
            if (oldOrder == null)
                throw new ApplicationException("不存在该订单");
            myOrderList.Remove(oldOrder);
            myOrderList.Add(order);
        }
        
        // 查询订单
        // 通过ID查询订单
        public Order FindOrder(int orderId)
        {
            var order = from s in myOrderList
                        where s.orderId == orderId
                        select s;
            if (!order.Any())
            {
                Console.WriteLine("订单不存在！");
                return null;
            }
            else
            {
                Order od = order.First();
                Console.WriteLine(od);
                return od;
            }
        }

        // 通过客户姓名查询此客户所有订单
        public List<Order> FindOrder(string customerName)
        {
            var order = from s in myOrderList
                        where s.customer.name == customerName
                        orderby s.totalPrice
                        select s;
            if (!order.Any())
            {
                Console.WriteLine("不存在此客户的订单！");
                return null;
            }
            else
            {
                List<Order> od = new List<Order>();
                od = order.ToList();
                foreach (var s in order)
                    Console.WriteLine(s);
                return od;
            }
        }

        // 通过商品名称查询包含此商品的所有订单
        public List<Order> FindOrderByGoods(string goodsName)
        {
            int len1 = myOrderList.ToArray().Length;
            List<Order> od = new List<Order>();
            for (int i = 0; i < len1; i++)
            {
                int len2 = myOrderList[i].orderList.ToArray().Length;
                for (int j = 0; j < len2; j++)
                    if (myOrderList[i].orderList[j].goodsItem.name == goodsName)
                        od.Add(myOrderList[i]);
            }
            var query = from s in od
                        orderby s.totalPrice
                        select s;
            if (!query.Any())
            {
                Console.WriteLine("不存在包含此商品的订单！");
                return null;
            }
            else
            {
                od = query.ToList();
                foreach (Order s in od)
                    Console.WriteLine(s);
                return od;
            }
        }

        // 查询全部订单
        public List<Order> FindOrder()
        {
            foreach (Order s in myOrderList)
                Console.WriteLine(s);
            return myOrderList;
        }

        // 序列化
        public void Export(string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(file, FileMode.Create))
                xmlSerializer.Serialize(fs, myOrderList);
        }

        // 反序列化
        public void Import(string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xmlSerializer.Deserialize(fs);
                temp.ForEach(order =>
                {
                    if (!myOrderList.Contains(order))
                        myOrderList.Add(order);
                });
            }
        }
    }
}
