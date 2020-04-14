using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServiceAPP
{
    public class Goods
    {
        public string id { get; set; }
        public string name { get; set; }
        public double perPrise { get; set; }

        public Goods() { }

        public Goods(string id, string name, double perPrise)
        {
            this.id = id;
            this.name = name;
            this.perPrise = perPrise;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null && id == goods.id && name == goods.name;
        }

        public override int GetHashCode()
        {
            var hashCode = -48284730;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            return hashCode;
        }
    }
}
