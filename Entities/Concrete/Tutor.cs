using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Tutor
    {
        [Key]
        public int TutorId { get; set; }
        [Required]
        public int TutorName { get; set; }
        public List<Course> Courses { get; set; }
    }
}
