using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CourseName { get; set; }
        public Tutor Tutor { get; set; }
        public List<Student> Students { get; set; }
        //Neden ICollection kullanmalıyım List yerine araştır.
    }
}
