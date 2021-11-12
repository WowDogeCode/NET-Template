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
    public class StudentManager : IStudentService
    {
        private IRepository<Student> _repository;
        private StudentValidator _validator = new StudentValidator();
        public StudentManager(IRepository<Student> repository) => _repository = repository;

        public void AddStudent(Student student)
        {
            var result = _validator.Validate(student);
            if (result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _repository.Add(student);
            _repository.Commit();
        }
        public void DeleteStudent(int id)
        {
            _repository.Delete(id);
            _repository.Commit();
        }
        public List<Student> GetAllStudents() => _repository.GetAll();
        public Student GetStudentById(int id) => _repository.GetById(id);
        public void UpdateStudent(Student student)
        {
            var result = _validator.Validate(student);
            if(result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _repository.Update(student);
            _repository.Commit();
        }
    }
}
