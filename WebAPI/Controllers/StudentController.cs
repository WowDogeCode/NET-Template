using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private IStudentService _studentService = new StudentManager();

        [HttpGet("students")]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return students != null ? Ok(students) : NotFound();
        }

        [HttpGet("student")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            return student != null ? Ok(student) : NotFound();
        }

        [HttpPost("add")]
        public IActionResult AddStudent(Student student)
        {
            _studentService.AddStudent(student);
            return Ok();
        }

        [HttpPost("save")]
        public IActionResult UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}
