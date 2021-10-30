using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Student
    {
        public int StudentId { get; set; }
        public int StudentName { get; set; }
        public List<Course> Courses { get; set; }
    }
}
