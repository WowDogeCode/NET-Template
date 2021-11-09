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
            var tutors = _tutorService.GetTutors();
            return tutors != null ? Ok(_mapper.Map<List<TutorDTO>> (tutors)) : NotFound();
        }

        [HttpGet("tutor")]
        public IActionResult GetTutor(int id)
        {
            var tutor = _tutorService.GetTutorById(id);
            return tutor != null ? Ok(_mapper.Map<TutorDTO> (tutor)) : NotFound();
        }

        [HttpPost("add")]
        public IActionResult AddTutor(Tutor tutor)
        {
            _tutorService.AddTutor(tutor);
            return Ok();
        }

        [HttpPost("save")]
        public IActionResult UpdateTutor(Tutor tutor)
        {
            _tutorService.UpdateTutor(tutor);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult DeleteTutor(int id)
        {
            _tutorService.DeleteTutor(id);
            return Ok();
        }
    }
}
