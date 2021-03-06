﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prev.Models
{
    public class Plan
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(120)]
        public string Description { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public List<User> Users { get; set; }

        public decimal Price { get; set; }
        public decimal Rate { get; set; }
        public Company Company { get; set; }
        public decimal Code { get; set; }
        public string Target { get; set; }

        [Required]
        public string ImageURL { get; set; }

    }
}
