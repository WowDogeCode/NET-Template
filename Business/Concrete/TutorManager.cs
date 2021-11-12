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
    public class TutorManager : ITutorService
    {
        private IRepository<Tutor> _repository;
        private TutorValidator _validator = new TutorValidator();
        public TutorManager(IRepository<Tutor> repository) => _repository = repository;

        public void AddTutor(Tutor tutor)
        {
            var result = _validator.Validate(tutor);
            if (result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _repository.Add(tutor);
            _repository.Commit();
        }
        public void DeleteTutor(int id)
        {
            _repository.Delete(id);
            _repository.Commit();
        }
        public Tutor GetTutorById(int id) => _repository.GetById(id);
        public List<Tutor> GetTutors() => _repository.GetAll();
        public void UpdateTutor(Tutor tutor)
        {
            var result = _validator.Validate(tutor);
            if (result.IsValid == false)
            {
                throw new Exception(result.Errors.First().ToString());
            }
            _repository.Update(tutor);
            _repository.Commit();
        }
    }
}
