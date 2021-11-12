using Business.Abstract;
using Business.Validation;
using DataAccess.Repository;
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
        private IRepository<Course> _repository;
        private CourseValidator _validator = new CourseValidator();
        public CourseManager(IRepository<Course> repository) => _repository = repository;

        public void AddCourse(Course course)
        {
            var result = _validator.Validate(course);
            if(result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _repository.Add(course);
            _repository.Commit();
        }
        public void DeleteCourse(int id)
        {
            _repository.Delete(id);
            _repository.Commit();
        }
        public List<Course> GetAllCourses() => _repository.GetAll();
        public Course GetCourseById(int id) => _repository.GetById(id);
        public void UpdateCourse(Course course)
        {
            var result = _validator.Validate(course);
            if(result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _repository.Update(course);
            _repository.Commit();
        }
    }
}
