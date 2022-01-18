using _0118SchoolApp.Data;
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
        public void Create(School school)
        {
            _schoolRepository.Create(school);
        }
        [HttpPut("{id}")]
        public void Update( int id, School schoolUpdate) // persikurti kaip DTO
        {
            var school = _schoolRepository.GetById(id);
            school.Name = schoolUpdate.Name;
            //school.Created = DateTime.UtcNow; //Ideti nauja sios akimirkos datetime? ar pasiimti kaip string?
            _schoolRepository.Update(school);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            _schoolRepository.Delete(id);
        }
    }
}
