using Business.Abstract;
using Business.Results;
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

        public IResult AddCourse(Course course)
        {
            var result = _validator.Validate(course);
            if(result.IsValid == false)
            {
                return new ErrorResult(result.Errors.First().ToString());
            }
            _repository.Add(course);
            _repository.Commit();
            return new SuccessfulResult();
        }
        public IResult DeleteCourse(int id)
        {
            _repository.Delete(id);
            _repository.Commit();
            return new SuccessfulResult();
        }
        public IDataResult<List<Course>> GetAllCourses() => new SuccessfulDataResult<List<Course>>(_repository.GetAll());
        public IDataResult<Course> GetCourseById(int id) => new SuccessfulDataResult<Course>(_repository.GetById(id));
        public IResult UpdateCourse(Course course)
        {
            var result = _validator.Validate(course);
            if(result.IsValid == false)
            {
                return new ErrorResult(result.Errors.First().ToString());
            }
            _repository.Update(course);
            _repository.Commit();
            return new SuccessfulResult();
        }
    }
}
