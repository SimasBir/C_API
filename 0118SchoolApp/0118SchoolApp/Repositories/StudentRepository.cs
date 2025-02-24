﻿using _0118SchoolApp.Data;
using _0118SchoolApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Repositories
{
    public class StudentRepository : RepositoryBase<Student>
    {
        public StudentRepository(DataContext context) : base(context)
        {

        }
        //public new List<Student> GetAll()
        //{
        //    List<Student> students = _context.Students.Include(s => s.School).ToList();
        //    return students;
        //}
        public new Student GetById(int id)
        {
            Student student = _context.Students.Include(s => s.School).Include(g => g.Gender).FirstOrDefault(t => t.Id == id);
            return student;
        }
        public List<Student> GetBySchool(int id)
        {
            List<Student> students = _context.Students.Where(a=>a.SchoolId==id).Include(s=>s.School).Include(g=>g.Gender).ToList();
            return students;
        }
    }
}
