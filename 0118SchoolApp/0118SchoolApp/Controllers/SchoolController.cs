using _0118SchoolApp.Data;
using _0118SchoolApp.Dtos;
using _0118SchoolApp.Models;
using _0118SchoolApp.Repositories;
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
        public List<School> GetAll()
        {
            return _schoolRepository.GetAll();
        }
        [HttpGet("{id}")]
        public School GetById(int id)
        {
            return _schoolRepository.GetById(id);
        }
        [HttpPost]
        public string Create(SchoolCreate schoolCreate)
        {
            if (!ModelState.IsValid)
            {
                return "Error, not created";
            }
            School school = new School()
            {
                Name = schoolCreate.Name,
                Created = schoolCreate.Created
            };
            _schoolRepository.Create(school);
            return "Created";
        }
        [HttpPut("{id}")]
        public string Update(int id, SchoolCreate schoolCreate)
        {
            if (!ModelState.IsValid)
            {
                return "Error, not updated";
            }
            var school = _schoolRepository.GetById(id);
            school.Name = schoolCreate.Name;
            //school.Created = DateTime.UtcNow; //Ideti nauja sios akimirkos datetime? ar pasiimti kaip string?
            school.Created = schoolCreate.Created;
            _schoolRepository.Update(school);
            return "Updated";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _schoolRepository.Delete(id);
            return "Deleted";
        }
    }
}
