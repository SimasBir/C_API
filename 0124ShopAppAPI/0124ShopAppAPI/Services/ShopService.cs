using _0124ShopAppAPI.Data;
using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Services
{
    public class ShopService : ServiceBase<Shop>
    {
        public ShopService(DataContext context) : base(context)
        {
        }
        private List<ViewShop> GetDto(List<Shop> allShops)
        {
            var shopList = new List<ViewShop>();
            foreach (var shop in allShops)
            {
                var newShop = new ViewShop()
                {
                    Id = shop.Id,
                    Name = shop.Name,
                    CreatedDate = shop.CreatedDate,
                    ShopItems = new List<ViewShopItem>()
                };
                foreach (var shopItem in shop.ShopItems)
                {
                    var newShopItem = new ViewShopItem()
                    {
                        Id = shopItem.Id,
                        Name = shopItem.Name,
                        Price = shopItem.Price,
                    };
                    newShop.ShopItems.Add(newShopItem);
                }
                shopList.Add(newShop);
            }
            return shopList;
        }

        public new List<ViewShop> GetAll()
        {
            var allShops = _context.Shops.Include(s => s.ShopItems).ToList();
            var shopList = GetDto(allShops);
            return shopList;
        }
        public new List<ViewShop> GetById(int id)
        {
            var allShops = _context.Shops.Include(s => s.ShopItems).Where(i => i.Id == id).ToList();
            if (allShops == null)
            {
                throw new ArgumentException($"Shop {id} not found");
            }
            var shopList = GetDto(allShops);
            return shopList;
        }
        public int Create(CreateShop createShop)
        {
            var existingName = _context.Shops.Select(s => s.Name).Contains(createShop.Name);
            if (existingName)
            {
                throw new ArgumentException($"Name {createShop.Name} already exists");
            }
            Shop shop = new Shop()
            {
                Name = createShop.Name, 
                CreatedDate = DateTime.UtcNow,
            };
            _context.Add(shop);
            _context.SaveChanges();
            return shop.Id;
        }
        public int Update(int id, CreateShop createShop)
        {
            var existingName = _context.Shops.Select(s => s.Name).Contains(createShop.Name);
            if (existingName)
            {
                throw new ArgumentException($"Name {createShop.Name} already exists");
            }
            var shop = base.GetById(id);
            if(shop == null)
            {
                throw new ArgumentException($"Shop with the id {id} was not found");
            }
            shop.Name = createShop.Name;
            _context.Update(shop);
            _context.SaveChanges();
            return shop.Id;
        }
    }
}
