using _0124ShopAppAPI.Data;
using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Validators;
using _0124ShopAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _0124ShopAppAPI.Services
{
    public class ShopItemService : ServiceBase<ShopItem>
    {
        private readonly CreateShopItemValidator _validator = new CreateShopItemValidator();
        private readonly IMapper _mapper;
        public ShopItemService(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        //private List<ViewShopItem> GetDto(List<ShopItem> allShopItems)
        //{
        //    var shopItemList = new List<ViewShopItem>();
        //    foreach (var shopItem in allShopItems)
        //    {
        //        var newShopItem = new ViewShopItem()
        //        {
        //            Id = shopItem.Id,
        //            Name = shopItem.Name,
        //            Price = shopItem.Price,
        //            ShopId = shopItem.ShopId,
        //        };
        //        shopItemList.Add(newShopItem);
        //    }
        //    return shopItemList;
        //}
        public new async Task<List<ViewShopItem>> GetAllAsync()
        {
            var allShopItems = await _context.ShopItems.Include(b=>b.Shop).ToListAsync();
            List<ViewShopItem> newItemList = new List<ViewShopItem>();
            foreach(var shopItem in allShopItems)
            {
                newItemList.Add(_mapper.Map<ViewShopItem>(shopItem));                
            }
            //var shopItemList = GetDto(allShopItems);
            return newItemList;
        }
        public new async Task<ViewShopItem> GetByIdAsync(int id)
        {
            var allShopItem = await _context.ShopItems.Where(i=>i.Id==id).Include(b => b.Shop).FirstOrDefaultAsync();
            if (allShopItem == null)
            {
                throw new ArgumentException($"ShopItem {id} not found");
            }
            var shopItemList = _mapper.Map<ViewShopItem>(allShopItem); // <destination>(source)
            //var shopItemList = GetDto(allShopItems);
            return shopItemList;
        }
        public async Task<int> CreateAsync(CreateShopItem createShopItem)
        {

            var validShopId = await _context.Shops.AnyAsync(s=>s.Id == createShopItem.ShopId);
            if (!validShopId)
            {
                throw new ArgumentException($"ShopId {createShopItem.ShopId} not found");
            }

            //CreateShopItemValidator _validator = new CreateShopItemValidator();
            _validator.ValidateAndThrow(createShopItem);
            ShopItem shopItem= _mapper.Map<ShopItem>(createShopItem);
            //ShopItem shopItem = new ShopItem()
            //{
            //    Name = createShopItem.Name,
            //    Price = createShopItem.Price,
            //    ShopId = createShopItem.ShopId,
            //};
            _context.Add(shopItem);
            await _context.SaveChangesAsync();
            return shopItem.Id;
        }
        public async Task<int> UpdateAsync(int id, CreateShopItem createShopItem)
        {            
            var shopItem = await base.GetByIdAsync(id);
            if(shopItem == null)
            {
                throw new ArgumentException($"ShopItem {id} not found");
            }
            var validShopId = await _context.Shops.AnyAsync(s => s.Id == createShopItem.ShopId);
            if (!validShopId)
            {
                throw new ArgumentException($"ShopId {createShopItem.ShopId} not found");
            }
            _validator.ValidateAndThrow(createShopItem);
            shopItem.Name = createShopItem.Name;
            shopItem.Price = createShopItem.Price;
            shopItem.ShopId = createShopItem.ShopId;
            _context.Update(shopItem);
            await _context.SaveChangesAsync();
            return shopItem.Id;
        }

    }
}
