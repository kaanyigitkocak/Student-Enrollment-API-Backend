using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SchoolValidator:AbstractValidator<School>
    {
        public SchoolValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s =>s.Address).NotEmpty();
        }
    }
}
