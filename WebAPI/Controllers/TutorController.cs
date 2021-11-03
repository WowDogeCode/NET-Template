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
    public class TutorController : ControllerBase
    {
        private ITutorDal _tutorDal = new TutorDal();

        [HttpGet("tutors")]
        public IActionResult GetAllTutors()
        {
            var tutors = _tutorDal.GetAll().ToList();
            return tutors != null ? Ok(tutors) : NotFound();
        }

        [HttpGet("tutor")]
        public IActionResult GetTutor(int id)
        {
            var tutor = _tutorDal.GetById(id);
            return tutor != null ? Ok(tutor) : NotFound();
        }

        [HttpPost("add")]
        public IActionResult AddTutor(Tutor tutor)
        {
            _tutorDal.Add(tutor);
            _tutorDal.Commit();
            return Ok();
        }

        [HttpPost("save")]
        public IActionResult UpdateTutor(Tutor tutor)
        {
            _tutorDal.Update(tutor);
            _tutorDal.Commit();
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult DeleteTutor(int id)
        {
            _tutorDal.Delete(id);
            _tutorDal.Commit();
            return Ok();
        }
    }
}
