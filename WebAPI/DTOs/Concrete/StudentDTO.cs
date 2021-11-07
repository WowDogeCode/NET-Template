using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs.Abstract;

namespace WebAPI.DTOs.Concrete
{
    public class StudentDTO : IDto
    {
        public int StudentId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public List<Course> Courses { get; set; }
    }
}
