using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ParentValidator:AbstractValidator<Parent>
    {
        public ParentValidator()
        {
            RuleFor(p => p.Phone).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
