using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal) => _courseDal = courseDal;

        public void AddCourse(Course course)
        {
            _courseDal.Add(course);
            _courseDal.Commit();
        }
        public void DeleteCourse(int id)
        {
            _courseDal.Delete(id);
            _courseDal.Commit();
        }
        public List<Course> GetAllCourses() => _courseDal.GetAll();
        public Course GetCourseById(int id) => _courseDal.GetById(id);
        public void UpdateCourse(Course course)
        {
            _courseDal.Update(course);
            _courseDal.Commit();
        }
    }
}
