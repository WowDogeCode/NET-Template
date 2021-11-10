using Business.Abstract;
using Business.Validation;
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
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;
        private StudentValidator _validator = new StudentValidator();
        public StudentManager(IStudentDal studentDal) => _studentDal = studentDal;

        public void AddStudent(Student student)
        {
            var result = _validator.Validate(student);
            if (result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _studentDal.Add(student);
            _studentDal.Commit();
        }
        public void DeleteStudent(int id)
        {
            _studentDal.Delete(id);
            _studentDal.Commit();
        }
        public List<Student> GetAllStudents() => _studentDal.GetAll();
        public Student GetStudentById(int id) => _studentDal.GetById(id);
        public void UpdateStudent(Student student)
        {
            var result = _validator.Validate(student);
            if(result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _studentDal.Update(student);
            _studentDal.Commit();
        }
    }
}
