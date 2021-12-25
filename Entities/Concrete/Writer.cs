using Core.Entities.Abstract;
using Entities.ValidationRules.FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Validator(typeof(WriterValidator))]
    public class Writer : IEntity
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<Heading> Headings { get; set; }
    }
}
