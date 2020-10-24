using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        //Read
        //GET api/students
        [HttpGet]
        public List<Student> GetAllStudents() //IEnumerable<Student> 이걸로 바꿔야하나..?
        {
            List<Student> students = _context.Read();
            return students;
        }

        //Create
        //POST api/students
        [HttpPost]
        public void PostStudents([FromBody]List<Student> students)
        {
            _context.Create(students);
        }

        //Update
        //PUT api/students
        [HttpPut]
        public void PutStudents([FromBody]List<Student> students)
        {
            _context.Update(students);
        }

        //Remove
        //DELETE api/students/{id}
        [HttpDelete("{id}")]
        public void DeleteStudents(int id)
        {
            _context.Remove(id);
        }

    }
}