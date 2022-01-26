using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Models;
using FluentValidation;

namespace _0124ShopAppAPI.Validators
{
    public class CreateShopItemValidator : AbstractValidator<CreateShopItem>
    {
        public CreateShopItemValidator()
        {
            RuleFor(item => item.Price).GreaterThan(4);
        }
    }
}
