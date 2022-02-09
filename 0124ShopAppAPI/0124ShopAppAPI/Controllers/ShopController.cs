using _0124ShopAppAPI.Dtos;
using _0124ShopAppAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
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
    public class ShopController : ControllerBase
    {
        private ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shopList = await _shopService.GetAllAsync();
            return Ok(shopList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
            var shopList = await _shopService.GetByIdAsync(id);
                return Ok(shopList);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateShop createShop)
        {
            //if (!ModelState.IsValid) 
            //{
            //    return BadRequest(ModelState); 
            //}
            try
            {
                var createdId = await _shopService.CreateAsync(createShop);
                return Created("Shop has been created. Id: ", createdId); //neraso to stringo, tai kam jis?
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
        public async Task<IActionResult> Update(int id, CreateShop createShop)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try
            {
                var createdId = await _shopService.UpdateAsync(id, createShop);
                return Created("Shop has been updated. Id: ", createdId);
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
                await _shopService.DeleteAsync(id);
                return Ok(id + " has been deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
