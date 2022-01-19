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
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
        [HttpPost]
        public string Create(StudentCreate studentCreate)
        {

            if (!ModelState.IsValid)
            {
                return "Error, not created";
            }
            if (new[] { 'm', 'f', 'u' }.Contains(Char.ToLower(studentCreate.Gender)))
            {
                Student student = new Student()
                {
                    Name = studentCreate.Name,
                    Gender = Char.ToLower(studentCreate.Gender),
                    SchoolId = studentCreate.SchoolId
                };
                _studentRepository.Create(student);
                return "Created";
            }
            else
            {
                return "Not created. Gender selection: m, f, u";
            }

        }
        [HttpPut("{id}")]
        public string Update(int id, StudentCreate studentCreate)
        {
            if (!ModelState.IsValid)
            {
                return "Error, not updated";
            }
            var student = _studentRepository.GetById(id);
            if (student != null)
            {
                if (new[] { 'm', 'f', 'u' }.Contains(Char.ToLower(studentCreate.Gender)))
                {
                    student.Name = studentCreate.Name;
                    student.Gender = studentCreate.Gender;
                    student.SchoolId = studentCreate.SchoolId;
                    _studentRepository.Update(student);
                    return "Updated";
                }
                else
                {
                    return "Not updated. Gender selection: m, f, u";
                }
            }
            else
            {
                return "Not updated. No such student";
            }
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _studentRepository.Delete(id);
            return "Deleted";
        }
    }
}
