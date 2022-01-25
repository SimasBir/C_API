using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Models
{
    public class ShopItem : NamedEntity
    {
        public double Price { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
    }
}
