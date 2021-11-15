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
    public class StudentManager : IStudentService
    {
        private IRepository<Student> _repository;
        private StudentValidator _validator = new StudentValidator();
        public StudentManager(IRepository<Student> repository) => _repository = repository;

        public IResult AddStudent(Student student)
        {
            var result = _validator.Validate(student);
            if (result.IsValid == false)
            {
                return new ErrorResult(result.Errors.First().ToString());
            }
            _repository.Add(student);
            _repository.Commit();
            return new SuccessfulResult();
        }
        public IResult DeleteStudent(int id)
        {
            _repository.Delete(id);
            _repository.Commit();
            return new SuccessfulResult();
        }
        public IDataResult<List<Student>> GetAllStudents() => new SuccessfulDataResult<List<Student>>(_repository.GetAll());
        public IDataResult<Student> GetStudentById(int id) => new SuccessfulDataResult<Student>(_repository.GetById(id));
        public IResult UpdateStudent(Student student)
        {
            var result = _validator.Validate(student);
            if(result.IsValid == false)
            {
                return new ErrorResult(result.Errors.First().ToString());
            }
            _repository.Update(student);
            _repository.Commit();
            return new SuccessfulResult();
        }
    }
}
