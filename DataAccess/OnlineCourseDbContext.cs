using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class OnlineCourseDbContext : DbContext
    {
        public OnlineCourseDbContext(DbContextOptions<OnlineCourseDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
    }
}
