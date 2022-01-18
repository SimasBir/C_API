using _0118SchoolApp.Data;
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
    }
}
