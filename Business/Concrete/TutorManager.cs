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
    public class TutorManager : ITutorService
    {
        private ITutorDal _tutorDal = new TutorDal();

        public void AddTutor(Tutor tutor)
        {
            _tutorDal.Add(tutor);
            _tutorDal.Commit();
        }
        public void DeleteTutor(int id)
        {
            _tutorDal.Delete(id);
            _tutorDal.Commit();
        }
        public Tutor GetTutorById(int id) => _tutorDal.GetById(id);
        public List<Tutor> GetTutors() => _tutorDal.GetAll();
        public void UpdateTutor(Tutor tutor)
        {
            _tutorDal.Update(tutor);
            _tutorDal.Commit();
        }
    }
}
