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
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        private IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        { 
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet("students")]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return students != null ? Ok(_mapper.Map<List<StudentDTO>> (students)) : NotFound();
        }

        [HttpGet("student")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            return student != null ? Ok(_mapper.Map<StudentDTO> (student)) : NotFound();
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
