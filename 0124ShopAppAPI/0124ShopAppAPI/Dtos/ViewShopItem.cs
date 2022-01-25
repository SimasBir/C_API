using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Dtos
{
    public class ViewShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ShopId { get; set; }
    }
}
