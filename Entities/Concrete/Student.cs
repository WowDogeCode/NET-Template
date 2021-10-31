using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Student : IEntity
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public int UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public List<Course> Courses { get; set; }
    }
}
