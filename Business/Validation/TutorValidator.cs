using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class TutorValidator : AbstractValidator<Tutor>
    {
        public TutorValidator()
        {
            RuleFor(tutor => tutor.TutorName).NotEmpty()
                .WithMessage("{PropertyName} can't be empty.");
            RuleFor(tutor => tutor.TutorName).Length(3, 20)
                .WithMessage("{PropertyName} length must be between 3-20 characters.");
        }
    }
}
