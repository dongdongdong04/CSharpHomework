using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp
{
    /**
     * 修改之前做的订单程序，基于EF框架，将订单保存到MySql数据库中，并实现订单的增删改查功能。
     * */
    public class OrderService
    {
        public OrderService() { }

        private static IQueryable<Order> AllOrders(OrderContext context)
        {
            return context.Orders.Include("Customer").Include(o => o.Items)
                        .Include(o => o.Items.Select(i => i.GoodsItem));
        }

        public static List<Order> GetAllOrders()
        {
            using (var context = new OrderContext())
            {
                return AllOrders(context).ToList();
            }
        }

        public static Order GetOrder(string id)
        {
            using (var context = new OrderContext())
            {
                //return context.Orders.SingleOrDefault(o => o.OrderId == id);
                return AllOrders(context).FirstOrDefault(o => o.OrderId == id);
            }
        }

        public static Order AddOrder(Order order)
        {
            try
            {
                using (var context = new OrderContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                return order;
            }catch(Exception e)
            {
                throw new ApplicationException($"添加错误: {e.Message}");
            }
        }

        public static void RemoveOrder(string orderId)
        {
            try
            {
                using(var context = new OrderContext())
                {
                    var order = context.Orders.Include("Items").FirstOrDefault(o => o.OrderId == orderId);
                    context.Orders.Remove(order);
                    context.SaveChanges();
                    
                }
            }catch(Exception e)
            {
                throw new ApplicationException($"删除订单错误: {e.Message}");
            }
        }

        public static List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            using(var context = new OrderContext())
            {
                //var order = context.Orders.
                var order = AllOrders(context)
                    .Where(o => o.Items.Exists(item => item.GoodsName == goodsName))
                    .OrderBy(o => o.TotalPrice);
                return order.ToList();
            }
        }

        public static List<Order> QueryOrdersByCustomerName(string customerName)
        {
            using (var context = new OrderContext())
            {
                //var order = context.Orders
                var order = AllOrders(context)
                    .Where(o => o.CustomerName == customerName)
                    .OrderBy(o => o.TotalPrice);
                return order.ToList();
            }
        }

        public static object QueryByTotalAmount(float amout)
        {
            using (var context = new OrderContext())
            {
                return AllOrders(context)
               .Where(order => order.TotalPrice >= amout)
               .OrderByDescending(o => o.TotalPrice)
               .ToList();
            }
        }
        
        public static void UpdateOrder(Order newOrder)
        {
            using(var context = new OrderContext())
            {
                var order = context.Orders.FirstOrDefault(o => o.OrderId == newOrder.OrderId);
                context.Orders.Remove(order);
                context.Orders.Add(newOrder);
                context.SaveChanges();
            }
        }

        public static void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using(var context = new OrderContext())
                {
                    xs.Serialize(fs, AllOrders(context).ToList());
                }
            }
        }

        public static void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach((Action<Order>)(order => {
                    try { AddOrder(order); }
                    catch { }
                }));
            }
        }
        
    }
}
