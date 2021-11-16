using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.StudentName).Length(2,20)
                .WithMessage("{PropertyName} length must be between 2-20 characters.");
            RuleFor(student => student.Balance).GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} can't be a negative value.");
        }
    }
}
