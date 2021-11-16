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
        public string StudentName { get; set; }
        public double Balance { get; set; }
        public List<Course> Courses { get; set; }
    }
}
