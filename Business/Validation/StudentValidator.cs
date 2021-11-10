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
            RuleFor(student => student.UserName).Length(2,20)
                .WithMessage("{PropertyName} length must be between 2-20 characters.");
            RuleFor(student => student.UserPassword).Length(8 - 20)
                .WithMessage("{PropertyName} length must be between 8-20 characters.");
        }
    }
}
