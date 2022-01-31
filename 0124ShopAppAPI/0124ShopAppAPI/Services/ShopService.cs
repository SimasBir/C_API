using _0124ShopAppAPI.Data;
using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Models;
using _0124ShopAppAPI.Validators;
using AutoMapper;
using FluentValidation;
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
        private readonly CreateShopValidator _validator = new CreateShopValidator();
        private readonly IMapper _mapper;
        public ShopService(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        //private List<ViewShop> GetDto(List<Shop> allShops)
        //{
        //    var shopList = new List<ViewShop>();
        //    foreach (var shop in allShops)
        //    {
        //        var newShop = new ViewShop()
        //        {
        //            Id = shop.Id,
        //            Name = shop.Name,
        //            CreatedDate = shop.CreatedDate,
        //            ShopItems = new List<ViewShopItem>()
        //        };
        //        foreach (var shopItem in shop.ShopItems)
        //        {
        //            var newShopItem = new ViewShopItem()
        //            {
        //                Id = shopItem.Id,
        //                Name = shopItem.Name,
        //                Price = shopItem.Price,
        //            };
        //            newShop.ShopItems.Add(newShopItem);
        //        }
        //        shopList.Add(newShop);
        //    }
        //    return shopList;
        //}

        public new async Task<List<ViewShop>> GetAllAsync()
        {
            var allShops = await _context.Shops.Include(s => s.ShopItems).ToListAsync();
            List<ViewShop> newShopList = new List<ViewShop>();
            foreach (var shop in allShops)
            {
                newShopList.Add(_mapper.Map<ViewShop>(shop));
            }
            //var shopList = GetDto(allShops);
            return newShopList;
        }
        public new async Task<ViewShop> GetByIdAsync(int id)
        {
            var allShop = await _context.Shops.Include(s => s.ShopItems).Where(i => i.Id == id).FirstOrDefaultAsync();
            if (allShop == null)
            {
                throw new ArgumentException($"Shop {id} not found");
            }
            var shop = _mapper.Map<ViewShop>(allShop);
            //var shopList = GetDto(allShops);
            return shop;
        }
        public async Task<int> CreateAsync(CreateShop createShop)
        {
            //var existingName = _context.Shops.Select(s => s.Name).Contains(createShop.Name);
            var existingName = _context.Shops.Any(s => s.Name == createShop.Name);

            if (existingName)
            {
                throw new ArgumentException($"Name {createShop.Name} already exists");
            }
            //CreateShopValidator validator = new CreateShopValidator();
            _validator.ValidateAndThrow(createShop);
            Shop shop = _mapper.Map<Shop>(createShop);
            //Shop shop = new Shop()
            //{
            //    Name = createShop.Name, 
            //    CreatedDate = DateTime.UtcNow,
            //};
            _context.Add(shop);
            await _context.SaveChangesAsync();
            return shop.Id;
        }
        public async Task<int> UpdateAsync(int id, CreateShop createShop)
        {
            var existingName = await _context.Shops.Select(s => s.Name).ContainsAsync(createShop.Name);
            if (existingName)
            {
                throw new ArgumentException($"Name {createShop.Name} already exists");
            }
            var shop = await base.GetByIdAsync(id);
            if(shop == null)
            {
                throw new ArgumentException($"Shop with the id {id} was not found");
            }
            //CreateShopValidator validator = new CreateShopValidator();
            _validator.ValidateAndThrow(createShop);
            shop.Name = createShop.Name;
            _context.Update(shop);
            await _context.SaveChangesAsync();
            return shop.Id;
        }
    }
}
