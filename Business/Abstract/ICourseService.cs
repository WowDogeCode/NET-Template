using Business.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<List<Course>> GetAllCourses();
        IDataResult<Course> GetCourseById(int id);
        IResult AddCourse(Course course);
        IResult UpdateCourse(Course course);
        IResult DeleteCourse(int id);
    }
}
