using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ConfirmationValidator:AbstractValidator<Confirmation>
    {
        public ConfirmationValidator()
        {
            RuleFor(c => c.CreatedDate).NotEmpty();
            RuleFor(c => c.LastDate).NotEmpty();
            RuleFor(c => c.UserPhone).NotEmpty();
            RuleFor(c => c.Code).NotEmpty();
        }
    }
}
