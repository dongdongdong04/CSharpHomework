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
            if (order.Any())
                throw new ApplicationException($"添加错误：订单号{myOrder.orderId} 已经存在!");
            myOrderList.Add(myOrder);
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
            return myOrderList.Where(o => o.orderId == orderId).FirstOrDefault();
        }

        // 通过客户姓名查询此客户所有订单
        public List<Order> FindOrder(string customerName)
        {
            return myOrderList
                .Where(order => order.customerName == customerName)
                .OrderBy(o => o.totalPrice)
                .ToList();
        }

        // 通过商品名称查询包含此商品的所有订单
        public List<Order> FindOrderByGoods(string goodsName)
        {
            var query = myOrderList
                .Where(order => order.orderList.Exists(item => item.goodsName == goodsName))
                .OrderBy(o => o.totalPrice);
            return query.ToList();
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
