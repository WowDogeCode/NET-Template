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
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal = new StudentDal();

        public void AddStudent(Student student)
        {
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
            _studentDal.Update(student);
            _studentDal.Commit();
        }
    }
}
