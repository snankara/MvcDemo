using Core.Entities.Abstract;
using Entities.ValidationRules.FluentValidation;
using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Validator(typeof(CategoryValidator))]
    public class Category : IEntity 
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        
        public bool Status { get; set; }

        public virtual ICollection<Heading> Headings { get; set; }
    }
}
