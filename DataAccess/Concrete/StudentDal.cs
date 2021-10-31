using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class StudentDal : EfRepositoryBase<Student>, IStudentDal { }
}
