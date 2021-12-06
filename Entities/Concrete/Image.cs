﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        [Key]
        public int ImageId { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(250)]
        public string ImagePath { get; set; }
    }
}
