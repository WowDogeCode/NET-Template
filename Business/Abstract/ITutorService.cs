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
        List<Tutor> GetTutors();
        Tutor GetTutorById(int id);
        void AddTutor(Tutor tutor);
        void UpdateTutor(Tutor tutor);
        void DeleteTutor(int id);
    }
}
