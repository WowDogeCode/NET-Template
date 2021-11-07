using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Abstract;

namespace WebAPI.DTOs.Concrete
{
    public class CourseDTO : IDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public Tutor Tutor { get; set; }
        public List<Student> Students { get; set; }
    }
}
