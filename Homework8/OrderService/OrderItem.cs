using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceAPP
{
    public class OrderItem
    {
        public int index { get; set; }
        public Goods goodsItem { get; set; }
        public int goodsQuantity { get; set; }

        public String goodsName { get => goodsItem != null ? this.goodsItem.name : ""; }
        public double perPrice { get => goodsItem != null ? this.goodsItem.perPrise : 0.0; }
        public double totalPrice { get => goodsItem != null ? 
                                   this.goodsItem.perPrise * this.goodsQuantity : 0.0; }
        
        public OrderItem() { }

        public OrderItem(int index, Goods goodsItem, int goodsQuantity)
        {
            this.index = index;
            this.goodsItem = goodsItem;
            this.goodsQuantity = goodsQuantity;
        }

        public override string ToString()
        {
            return $"[No.:{index},goods:{goodsName},quantity:{goodsQuantity},totalPrice:{totalPrice}]";
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null && item.goodsItem.id == goodsItem.id;
        }

        public override int GetHashCode()
        {
            var hashCode = -973750183;
            hashCode = hashCode * -1521134295 + index.GetHashCode();
            hashCode = hashCode * -1521134295 + goodsQuantity.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(goodsName);
            return hashCode;
        }
    }
}
