using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Dtos
{
    public class CreateShop
    {
        //[MinLength(4)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
