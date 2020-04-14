using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace OrderServiceAPP
{
    public class Order
    {
        public List<OrderItem> orderList { get; set; }
        public int orderId { get; set; }
        public DateTime orderTime { get; set; }
        public Customer customer { get; set; }

        public String customerName { get => customer != null ? customer.name : ""; }
        public double totalPrice { get => orderList.Sum(orderList => orderList.totalPrice); }

        // 构造函数
        public Order()
        {
            orderList = new List<OrderItem>();
            orderTime = DateTime.Now;
        }

        public Order(int orderId, Customer customer, List<OrderItem> orderList)
        {
            this.orderId = orderId;
            this.orderTime = DateTime.Now;
            this.customer = customer;
            this.orderList = orderList == null ? new List<OrderItem>() : orderList;
        }
        
        // 对订单明细的添加和删除
        public void AddItem(OrderItem orderItem)
        {
            if (orderList.Contains(orderItem)) // 若List中已存在该类货物，则认为数量叠加
            {
                for(int i = 0; i < orderList.ToArray().Length; i++)
                    if (orderList[i].Equals(orderItem))  
                    {
                        orderList[i].goodsQuantity += orderItem.goodsQuantity;
                        break;
                    }
            }
            else orderList.Add(orderItem);     // 否则添加新明细
        }

        public void DeleteItem(OrderItem orderItem)
        {
            orderList.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{orderId}, customer:{customer},orderTime:{orderTime},totalPrice：{totalPrice}");
            orderList.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && order.orderId == orderId;
        }

        public override int GetHashCode()
        {
            var hashCode = -875721150;
            hashCode = hashCode * -1521134295 + orderId.GetHashCode();
            hashCode = hashCode * -1521134295 + orderTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(customerName);
            return hashCode;
        }

        // 还没搞懂
        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            else return this.orderId.CompareTo(other.orderId);
        }
    }
}
