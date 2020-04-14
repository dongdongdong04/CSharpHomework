using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceAPP
{
    public class Customer
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public Customer() { }

        public Customer(string ID, string name, string address)
        {
            this.ID = ID;
            this.address = address;
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null && ID == customer.ID && name == customer.name;
        }

        public override int GetHashCode()
        {
            var hashCode = -712093626;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            return hashCode;
        }
    }
}
