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
    public class TutorManager : ITutorService
    {
        private ITutorDal _tutorDal;
        private TutorValidator _validator = new TutorValidator();
        public TutorManager(ITutorDal tutorDal) => _tutorDal = tutorDal;

        public void AddTutor(Tutor tutor)
        {
            var result = _validator.Validate(tutor);
            if (result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
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
            var result = _validator.Validate(tutor);
            if (result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _tutorDal.Update(tutor);
            _tutorDal.Commit();
        }
    }
}
