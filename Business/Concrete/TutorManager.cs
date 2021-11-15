using Business.Abstract;
using Business.Results;
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

        public IResult AddTutor(Tutor tutor)
        {
            var result = _validator.Validate(tutor);
            if (result.IsValid == false)
            {
                return new ErrorResult(result.Errors.First().ToString());
            }
            _repository.Add(tutor);
            _repository.Commit();
            return new SuccessfulResult();
        }
        public IResult DeleteTutor(int id)
        {
            _repository.Delete(id);
            _repository.Commit();
            return new SuccessfulResult();
        }
        public IDataResult<Tutor> GetTutorById(int id) => new SuccessfulDataResult<Tutor>(_repository.GetById(id));
        public IDataResult<List<Tutor>> GetTutors() => new SuccessfulDataResult<List<Tutor>>(_repository.GetAll());
        public IResult UpdateTutor(Tutor tutor)
        {
            var result = _validator.Validate(tutor);
            if (result.IsValid == false)
            {
                return new ErrorResult(result.Errors.First().ToString());
            }
            _repository.Update(tutor);
            _repository.Commit();
            return new SuccessfulResult();
        }
    }
}
