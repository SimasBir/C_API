using _0118SchoolApp.Data;
using _0118SchoolApp.Dtos;
using _0118SchoolApp.Models;
using _0118SchoolApp.Repositories;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private SchoolRepository _schoolRepository;
        public SchoolController(SchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_schoolRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
                return new ObjectResult(_schoolRepository.GetById(id)) { StatusCode = 302}; //302-found
        }

        //[HttpPost()]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPost]
        public IActionResult Create(SchoolCreate schoolCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error, not created");
            }
            School school = new School()
            {
                Name = schoolCreate.Name,
                Created = schoolCreate.Created
            };
            _schoolRepository.Create(school);
            return new ObjectResult("Created") { StatusCode = 201 }; //201 - created
            
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, SchoolCreate schoolCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var school = _schoolRepository.GetById(id);
            school.Name = schoolCreate.Name;
            //school.Created = DateTime.UtcNow; //Ideti nauja sios akimirkos datetime? ar pasiimti kaip string?
            school.Created = schoolCreate.Created;
            _schoolRepository.Update(school);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _schoolRepository.Delete(id);
            return Ok("Deleted");
        }
    }
}
