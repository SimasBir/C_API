using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Dtos
{
    public class CreateShopItem
    {
        public string Name { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Price cannot be below zero.")]
        public double Price { get; set; }
        public int ShopId { get; set; }
    }
}
