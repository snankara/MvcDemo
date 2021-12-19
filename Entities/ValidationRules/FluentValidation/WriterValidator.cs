using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.FirstName).NotEmpty().WithMessage("Yazar adı boş olamaz !");
            RuleFor(w => w.LastName).NotEmpty().WithMessage("Yazar soyadı boş olamaz ! !");
            RuleFor(w => w.Email).NotEmpty().WithMessage("Yazar e-mail adresi boş olamaz ! !");
        }
    }
}
