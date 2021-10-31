using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class OnlineCourseDbContext : DbContext
    {
        public OnlineCourseDbContext(DbContextOptions<OnlineCourseDbContext> contextOptions) : base(contextOptions) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
    }
}
