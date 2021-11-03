using DataAccess.Abstract;
using DataAccess.Concrete;
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
        private IStudentDal _studentDal = new StudentDal();

        [HttpGet("students")]
        public IActionResult GetAllStudents()
        {
            var students = _studentDal.GetAll();
            return students != null ? Ok(students) : NotFound();
        }

        [HttpGet("student")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentDal.GetById(id);
            return student != null ? Ok(student) : NotFound();
        }

        [HttpPost("add")]
        public IActionResult AddStudent(Student student)
        {
            _studentDal.Add(student);
            _studentDal.Commit();
            return Ok();
        }

        [HttpPost("save")]
        public IActionResult UpdateStudent(Student student)
        {
            _studentDal.Update(student);
            _studentDal.Commit();
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult DeleteStudent(int id)
        {
            _studentDal.Delete(id);
            _studentDal.Commit();
            return Ok();
        }
    }
}
