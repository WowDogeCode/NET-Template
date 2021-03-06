using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Course : IEntity
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public double Price { get; set; }
        public Tutor Tutor { get; set; }
        public List<Student> Students { get; set; }
    }
}
