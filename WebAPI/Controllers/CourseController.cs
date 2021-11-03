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
    public class CourseController : ControllerBase
    {
        private ICourseDal _courseDal = new CourseDal();

        [HttpGet("courses")]
        public IActionResult GetAllCourses()
        {
            var courses = _courseDal.GetAll().ToList();
            return courses != null ? Ok(courses) : NotFound();
        }

        [HttpGet("course")]
        public IActionResult GetCourse(int id)
        {
            var course = _courseDal.GetById(id);
            return course != null ? Ok(course) : NotFound();
        }

        [HttpPost("add")]
        public IActionResult AddCourse(Course course)
        {
            _courseDal.Add(course);
            _courseDal.Commit();
            return Ok();
        }

        [HttpPost("save")]
        public IActionResult UpdateCourse(Course course)
        {
            _courseDal.Update(course);
            _courseDal.Commit();
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult DeleteCourse(int id)
        {
            _courseDal.Delete(id);
            _courseDal.Commit();
            return Ok();
        }
    }
}
