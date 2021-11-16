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
            var result = _studentService.GetAllStudents();
            return result.Successful ? Ok(_mapper.Map<List<StudentDTO>> (result.Data)) : NotFound(result.Message);
        }

        [HttpGet("student")]
        public IActionResult GetStudent(int id)
        {
            var result = _studentService.GetStudentById(id);
            return result.Successful ? Ok(_mapper.Map<StudentDTO> (result.Data)) : NotFound(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddStudent(Student student)
        {
            var result = _studentService.AddStudent(student);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("save")]
        public IActionResult UpdateStudent(Student student)
        {
            var result = _studentService.UpdateStudent(student);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _studentService.DeleteStudent(id);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
