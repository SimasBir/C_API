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
        public new List<ViewShopItem> GetAll()
        {
            var allShopItems = _context.ShopItems.ToList();
            List<ViewShopItem> newItemList = new List<ViewShopItem>();
            foreach(var shopItem in allShopItems)
            {
                newItemList.Add(_mapper.Map<ViewShopItem>(shopItem));
            }
            //var shopItemList = GetDto(allShopItems);
            return newItemList;
        }
        public new ViewShopItem GetById(int id)
        {
            var allShopItem = _context.ShopItems.Where(i=>i.Id==id).FirstOrDefault();
            if (allShopItem == null)
            {
                throw new ArgumentException($"ShopItem {id} not found");
            }
            var shopItemList = _mapper.Map<ViewShopItem>(allShopItem); // <destination>(source)
            //var shopItemList = GetDto(allShopItems);
            return shopItemList;
        }
        public int Create(CreateShopItem createShopItem)
        {

            var validShopId = _context.Shops.Any(s=>s.Id == createShopItem.ShopId);
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
            _context.SaveChanges();
            return shopItem.Id;
        }
        public int Update(int id, CreateShopItem createShopItem)
        {            
            var shopItem = base.GetById(id);
            if(shopItem == null)
            {
                throw new ArgumentException($"ShopItem {id} not found");
            }
            var validShopId = _context.Shops.Any(s => s.Id == createShopItem.ShopId);
            if (!validShopId)
            {
                throw new ArgumentException($"ShopId {createShopItem.ShopId} not found");
            }
            _validator.ValidateAndThrow(createShopItem);
            shopItem.Name = createShopItem.Name;
            shopItem.Price = createShopItem.Price;
            shopItem.ShopId = createShopItem.ShopId;
            _context.Update(shopItem);
            _context.SaveChanges();
            return shopItem.Id;
        }
    }
}
