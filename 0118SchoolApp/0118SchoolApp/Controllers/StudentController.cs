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
    public class StudentController : ControllerBase
    {
        private StudentRepository _studentRepository;
        private GenderRepository _genderRepository;
        private SchoolRepository _schoolRepository;
        public StudentController(StudentRepository studentRepository, GenderRepository genderRepository, SchoolRepository schoolRepository)
        {
            _studentRepository = studentRepository;
            _genderRepository = genderRepository;
            _schoolRepository = schoolRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (_studentRepository.GetById(id) != null)
            {
                Student student = _studentRepository.GetById(id);
                StudentView studentView = new StudentView()
                {
                    Name = student.Name,
                    Gender = student.Gender.Name,
                    School = student.School.Name,
                };
                return Ok(studentView);
            }
            else
            {
                return NotFound("No such student");
            }
        }
        [HttpPost]
        public IActionResult Create(StudentCreate studentCreate)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Model state not valid");
            }
            //if (new[] { 'm', 'f', 'u' }.Contains(Char.ToLower(studentCreate.Gender)))
            //{
            if (_genderRepository.GetById(studentCreate.GenderId) == null || _schoolRepository.GetById(studentCreate.SchoolId) == null)
            {
                return BadRequest("Selection not possible");
            }
            else
            {
                Student student = new Student()
                {
                    Name = studentCreate.Name,
                    //Gender = Char.ToLower(studentCreate.Gender),
                    GenderId = studentCreate.GenderId,
                    SchoolId = studentCreate.SchoolId
                };
                _studentRepository.Create(student);
                return Created("Created", studentCreate);
            }
            //}
            //else
            //{
            //    return "Not created. Gender selection: m, f, u";
            //}

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentCreate studentCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model state not valid");
            }
            if (_genderRepository.GetById(studentCreate.GenderId) == null || _schoolRepository.GetById(studentCreate.SchoolId) == null)
            {
                return BadRequest("Selection not possible");
            }
            else
            {
                var student = _studentRepository.GetById(id);
                if (student != null)
                {
                    student.Name = studentCreate.Name;
                    //student.Gender = studentCreate.Gender;
                    student.GenderId = studentCreate.GenderId;
                    student.SchoolId = studentCreate.SchoolId;
                    _studentRepository.Update(student);
                    return Ok("Updated");

                }
                else
                {
                    return NotFound("Student with such ID does not exist");
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentRepository.Delete(id);
            return Ok("Deleted");
        }
    }
}
