using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adı boş olamaz !");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Kategori açıklaması boş olamaz !");
            RuleFor(c => c.Name).MaximumLength(20).WithMessage("Kategori adı max 20 karakter olmalıdır !");
            RuleFor(c => c.Description).MaximumLength(50).WithMessage("Kategori açıklaması max 50 karakter olmalıdır !");
        }
    }
}
