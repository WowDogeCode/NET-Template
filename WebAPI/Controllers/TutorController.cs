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
    public class TutorController : ControllerBase
    {
        private ITutorService _tutorService;
        private IMapper _mapper;

        public TutorController(ITutorService tutorService, IMapper mapper)
        {
            _tutorService = tutorService;
            _mapper = mapper;
        }
        [HttpGet("tutors")]
        public IActionResult GetAllTutors()
        {
            var result = _tutorService.GetTutors();
            return result.Successful ? Ok(_mapper.Map<List<TutorDTO>> (result.Data)) : NotFound(result.Message);
        }

        [HttpGet("tutor")]
        public IActionResult GetTutor(int id)
        {
            var result = _tutorService.GetTutorById(id);
            return result.Successful ? Ok(_mapper.Map<TutorDTO> (result.Data)) : NotFound(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddTutor(Tutor tutor)
        {
            var result = _tutorService.AddTutor(tutor);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("save")]
        public IActionResult UpdateTutor(Tutor tutor)
        {
            var result = _tutorService.UpdateTutor(tutor);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult DeleteTutor(int id)
        {
            var result = _tutorService.DeleteTutor(id);
            return result.Successful ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
