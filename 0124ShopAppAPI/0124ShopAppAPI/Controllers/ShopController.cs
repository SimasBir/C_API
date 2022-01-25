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
    public class ShopController : ControllerBase
    {
        private ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var shopList = _shopService.GetAll();
            return Ok(shopList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
            var shopList = _shopService.GetById(id);
                return Ok(shopList);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(CreateShop createShop)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }
            try
            {
                var createdId = _shopService.Create(createShop);
                return Created("Shop has been created. Id: ", createdId); //neraso to stringo, tai kam jis?
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateShop createShop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdId = _shopService.Update(id, createShop);
                return Created("Shop has been updated. Id: ", createdId);
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
                _shopService.Delete(id);
                return Ok(id + " has been deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
