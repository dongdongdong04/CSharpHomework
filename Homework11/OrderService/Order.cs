using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OrderApp
{
    public class Order : IComparable<Order>
    {
        public string OrderId { get; set; }

        public List<OrderItem> Items;

        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public string CustomerName { get => (Customer != null) ? Customer.Name : ""; }

        public DateTime CreateTime { get; set; }
        
        public Order() {
            OrderId = Guid.NewGuid().ToString();
            Items = new List<OrderItem>();
            CreateTime = DateTime.Now;
        }

        public Order(Customer customer, List<OrderItem> items)
        {
            this.Customer = customer;
            this.CreateTime = DateTime.Now;
            this.Items = (items == null) ? new List<OrderItem>() : items;
        }

        public double TotalPrice
        {
            get => Items.Sum(item => item.TotalPrice);
        }

        public void AddItem(OrderItem orderItem)
        {
            if (Items.Contains(orderItem))
                throw new ApplicationException($"添加错误：订单项已经存在!");
            Items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{OrderId}, customer:{Customer},orderTime:{CreateTime},totalPrice：{TotalPrice}");
            Items.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            var hashCode = -531220479;
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
            hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return this.OrderId.CompareTo(other.OrderId);
        }
    }
}
