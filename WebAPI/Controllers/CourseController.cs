using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Concrete;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        private IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        [HttpGet("courses")]
        public IActionResult GetAllCourses()
        {
            var result = _courseService.GetAllCourses();
            return result.Successful ? Ok(_mapper.Map<List<CourseDTO>>(result.Data)) : NotFound(result.Message);
        }

        [HttpGet("course")]
        public IActionResult GetCourse(int id)
        {
            var result = _courseService.GetCourseById(id);
            return result.Successful ? Ok(_mapper.Map<CourseDTO>(result.Data)) : NotFound(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddCourse(Course course)
        {
            var result = _courseService.AddCourse(course);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("save")]
        public IActionResult UpdateCourse(Course course)
        {
            var result = _courseService.UpdateCourse(course);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult DeleteCourse(int id)
        {
            var result = _courseService.DeleteCourse(id);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
