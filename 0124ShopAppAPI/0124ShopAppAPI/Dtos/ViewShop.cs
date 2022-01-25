using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Dtos
{
    public class ViewShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ViewShopItem> ShopItems { get; set; }

    }
}
