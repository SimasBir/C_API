using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Services;
using FluentValidation;
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
        public async Task<IActionResult> GetAll()
        {
            var shopList = await _shopItemService.GetAllAsync();
            return Ok(shopList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var shopList = await _shopItemService.GetByIdAsync(id);
                return Ok(shopList);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateShopItem createShopItem)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try
            {
                var createdId = await _shopItemService.CreateAsync(createShopItem);
                return Created("ShopItem has been created. Id: ", createdId);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateShopItem createShopItem)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try
            {
                var createdId = await _shopItemService.UpdateAsync(id, createShopItem);
                return Created("ShopItem has been updated. Id: ", createdId);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shopItemService.DeleteAsync(id);
                return Ok(id + " has been deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
