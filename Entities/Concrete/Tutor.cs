using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Tutor
    {
        public int TutorId { get; set; }
        public int TutorName { get; set; }
        public List<Course> Courses { get; set; }
    }
}
