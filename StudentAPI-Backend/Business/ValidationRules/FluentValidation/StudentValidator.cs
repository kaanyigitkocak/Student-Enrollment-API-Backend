using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class StudentValidator: AbstractValidator<Student>
    {

        public StudentValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.ParentId).NotEmpty();
            RuleFor(s => s.SchoolId).NotEmpty();
            RuleFor(s => s.Age).LessThanOrEqualTo(7);

        }

    }
}
