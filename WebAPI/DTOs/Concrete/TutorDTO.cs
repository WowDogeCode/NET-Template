using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Abstract;

namespace WebAPI.DTOs.Concrete
{
    public class TutorDTO : IDto
    {
        public int TutorId { get; set; }
        public string TutorName { get; set; }
        public List<Course> Courses { get; set; }
    }
}
