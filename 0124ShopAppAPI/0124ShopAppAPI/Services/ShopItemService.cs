using _0124ShopAppAPI.Data;
using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Services
{
    public class ShopItemService : ServiceBase<ShopItem>
    {
        public ShopItemService(DataContext context) : base(context)
        {
        }
        private List<ViewShopItem> GetDto(List<ShopItem> allShopItems)
        {
            var shopItemList = new List<ViewShopItem>();
            foreach (var shopItem in allShopItems)
            {
                var newShopItem = new ViewShopItem()
                {
                    Id = shopItem.Id,
                    Name = shopItem.Name,
                    Price = shopItem.Price,
                    ShopId = shopItem.ShopId,
                };
                shopItemList.Add(newShopItem);
            }
            return shopItemList;
        }
        public new List<ViewShopItem> GetAll()
        {
            var allShopItems = _context.ShopItems.ToList();
            var shopItemList = GetDto(allShopItems);
            return shopItemList;
        }
        public new List<ViewShopItem> GetById(int id)
        {
            var allShopItems = _context.ShopItems.Where(i=>i.Id==id).ToList();
            if (allShopItems == null)
            {
                throw new ArgumentException($"ShopItem {id} not found");
            }
            var shopItemList = GetDto(allShopItems);
            return shopItemList;
        }
        public int Create(CreateShopItem createShopItem)
        {
            var validShopId = _context.Shops.Any(s=>s.Id == createShopItem.ShopId);
            if (!validShopId)
            {
                throw new ArgumentException($"ShopId {createShopItem.ShopId} not found");
            }
            ShopItem shopItem = new ShopItem()
            {
                Name = createShopItem.Name,
                Price = createShopItem.Price,
                ShopId = createShopItem.ShopId,
            };
            _context.Add(shopItem);
            _context.SaveChanges();
            return shopItem.Id;
        }
        public int Update(int id, CreateShopItem createShopItem)
        {
            var shopItem = base.GetById(id);
            shopItem.Name = createShopItem.Name;
            shopItem.Price = createShopItem.Price;
            shopItem.ShopId = createShopItem.ShopId;
            _context.Update(shopItem);
            _context.SaveChanges();
            return shopItem.Id;
        }
    }
}
