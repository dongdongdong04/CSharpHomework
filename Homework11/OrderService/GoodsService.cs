using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class GoodsService
    {
        public static void AddGood(Goods goods)
        {
            try
            {
                using (var context = new OrderContext())
                {
                    context.GoodItems.Add(goods);
                    context.SaveChanges();
                }
            }
            catch{
                throw new ApplicationException($"添加错误!");
            }
        }

        public static List<Goods> GetAllGoods()
        {
            using (var context = new OrderContext())
            {
                return context.GoodItems.ToList();
            }
        }
    }
}
