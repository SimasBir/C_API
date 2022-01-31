using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.AutoMapper
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Shop, CreateShop>().ReverseMap();
            CreateMap<Shop, ViewShop>();
            CreateMap<ShopItem, CreateShopItem>().ReverseMap();
            CreateMap<ShopItem, ViewShopItem>()/*.ForMember(dest=>dest.ShopName, opt=>opt.MapFrom(src => src.Shop.Name))*/;
        }
    }
}
