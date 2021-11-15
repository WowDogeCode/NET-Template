using Business.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService 
    {
        IDataResult<List<Student>> GetAllStudents();
        IDataResult<Student> GetStudentById(int id);
        IResult AddStudent(Student student);
        IResult UpdateStudent(Student student);
        IResult DeleteStudent(int id);
    }
}
