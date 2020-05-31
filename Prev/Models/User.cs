using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prev.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(120)]
        public string Password { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(120)]
        public string Email { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string CPF { get; set; }


        [Required]
        public decimal Phone { get; set; }

        public double Points { get; set; }
        public string UserCode { get; set; }
        public string Target { get; set; }
        public Plan Plan { get; set; }
        public bool firstLogin { get; set; }

    }
}
