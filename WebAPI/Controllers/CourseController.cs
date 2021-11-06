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
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService) => _courseService = courseService;

        [HttpGet("courses")]
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.GetAllCourses();
            return courses != null ? Ok(courses) : NotFound();
        }

        [HttpGet("course")]
        public IActionResult GetCourse(int id)
        {
            var course = _courseService.GetCourseById(id);
            return course != null ? Ok(course) : NotFound();
        }

        [HttpPost("add")]
        public IActionResult AddCourse(Course course)
        {
            _courseService.AddCourse(course);
            return Ok();
        }

        [HttpPost("save")]
        public IActionResult UpdateCourse(Course course)
        {
            _courseService.UpdateCourse(course);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
            return Ok();
        }
    }
}
