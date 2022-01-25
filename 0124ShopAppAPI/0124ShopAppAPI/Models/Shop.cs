using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Models
{
    public class Shop : NamedEntity
    {
        public DateTime CreatedDate { get; set; } 
        public List<ShopItem> ShopItems { get; set; }
    }
}
