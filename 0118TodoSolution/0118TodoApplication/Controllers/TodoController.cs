using _0118TodoApplication.Data;
using _0118TodoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118TodoApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public TodoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public List<Todo> HttpGetAll(Todo todo) // Kai norime gauti resursus
        {
            return _dataContext.Todos.ToList();
        } 
        [HttpGet("{id}")]
        public Todo HttpGetById(int id) // Kai norime gauti resursus
        {
            return _dataContext.Todos.Find(id);
        }
        [HttpPost]
        public void Create(Todo todo) // Kai norim sukurti resursus
        {
            _dataContext.Todos.Add(todo);
            _dataContext.SaveChanges();
        }
        [HttpPut("{id}")]
        public void Update(/*[FromRoute]*/ int id,/*[FromBody]*/ Todo todoUpdate) // Kai norim update'inti resursus
        {
            var todo = _dataContext.Todos.Find(id);
            todo.Name = todoUpdate.Name;
            _dataContext.SaveChanges();

        }
        [HttpDelete("{id}")]
        public void Delete(int id) // Kai norim trinti resursus
        {
            var todo = _dataContext.Todos.Find(id);
            _dataContext.Remove(todo);
            _dataContext.SaveChanges();
        }
    }
}
