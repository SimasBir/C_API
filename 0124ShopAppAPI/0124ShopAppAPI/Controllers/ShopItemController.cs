using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0124ShopAppAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopItemController : ControllerBase
    {
        private ShopItemService _shopItemService;
        public ShopItemController(ShopItemService shopItemService)
        {
            _shopItemService = shopItemService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var shopList = _shopItemService.GetAll();
            return Ok(shopList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var shopList = _shopItemService.GetById(id);
                return Ok(shopList);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(CreateShopItem createShopItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdId = _shopItemService.Create(createShopItem);
                return Created("ShopItem has been created. Id: ", createdId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateShopItem createShopItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdId = _shopItemService.Update(id, createShopItem);
                return Created("ShopItem has been updated. Id: ", createdId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _shopItemService.Delete(id);
                return Ok(id + " has been deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
