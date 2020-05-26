using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class CustomerService
    {
        public static void AddCustomer(Customer customer)
        {
            try
            {
                using (var context = new OrderContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
            }
            catch{
                throw new ApplicationException($"添加错误!");
            }
        }

        public static List<Customer> GetAllCustomers()
        {
            using (var context = new OrderContext())
            {
                return context.Customers.ToList();
            }
        }
    }
}
