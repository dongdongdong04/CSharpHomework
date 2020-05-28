using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homework12.Models;

namespace Homework12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;
        }

        private IQueryable<Order> AllOrders()
        {
            return _context.Orders.Include("Customer").Include(o => o.Items)
                        .Include(o => o.Items.Select(i => i.GoodsItem));
        }

        // GET: api/order/ini
        // 初始化
        [HttpGet("ini")]
        public ActionResult<List<Order>> InitializeOrders()
        {
            Order order = new Order(new Customer("li"), new List<OrderItem>());
            order.AddItem(new OrderItem(1, new Goods("apple", 100.0), 10));
            Order order2 = new Order(new Customer("zhang"), new List<OrderItem>());
            order2.AddItem(new OrderItem(1, new Goods("egg", 200.0), 10));
            try
            {
                _context.Orders.Add(order);
                _context.Orders.Add(order2);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return AllOrders().ToList();
        }

        // GET:api/order
        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            return AllOrders().ToList();
        }

        // GET:api/order/{id}
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            //return context.Orders.SingleOrDefault(o => o.OrderId == id);
            return AllOrders().FirstOrDefault(o => o.OrderId == id);
        }

        // POST:api/order
        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return order;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        // DELETE:api/order/{id}
        [HttpDelete("{id}")]
        public ActionResult<Order> RemoveOrder(string orderId)
        {
            try
            {
                var order = _context.Orders.Include("Items").FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    for (int i = 0; i < order.Items.Count; i++)
                    {
                        _context.GoodItems.Remove(order.Items[i].GoodsItem);
                        _context.OrderItems.Remove(order.Items[i]);
                    }
                    _context.Customers.Remove(order.Customer);
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                }
            }catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        // GET:api/order/goods?name=
        [HttpGet("goods")]
        public ActionResult<List<Order>> QueryOrdersByGoodsName(string goodsName)
        {
            //var order = context.Orders.
            var order = AllOrders()
                    .Where(o => o.Items.Exists(item => item.GoodsName == goodsName))
                    .OrderBy(o => o.TotalPrice);
            return order.ToList();
        }
        
        // GET:api/order/customer?name=
        [HttpGet("customer")]
        public ActionResult<List<Order>> QueryOrdersByCustomerName(string customerName)
        {
            //var order = context.Orders
            var order = AllOrders()
                .Where(o => o.CustomerName == customerName)
                .OrderBy(o => o.TotalPrice);
            return order.ToList();
        }

        // GET:api/order/total?amount=
        [HttpGet("total")]
        public ActionResult<List<Order>> QueryByTotalAmount(float amout)
        {
            return AllOrders()
               .Where(order => order.TotalPrice >= amout)
               .OrderByDescending(o => o.TotalPrice)
               .ToList();
        }

        // PUT:api/order
        public ActionResult<Order> UpdateOrder(Order newOrder)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderId == newOrder.OrderId);
                _context.Orders.Remove(order);
                _context.Orders.Add(newOrder);
                _context.SaveChanges();
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
    
    }
}
