using Business.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITutorService
    {
        IDataResult<List<Tutor>> GetTutors();
        IDataResult<Tutor> GetTutorById(int id);
        IResult AddTutor(Tutor tutor);
        IResult UpdateTutor(Tutor tutor);
        IResult DeleteTutor(int id);
    }
}
