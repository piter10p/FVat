using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    abstract class Addressable
    {
        [Required]
        public string Street { get; set; }
        
        [Required, MaxLength(16)]
        public string Number { get; set; }

        [StringLength(maximumLength: 5, MinimumLength = 5)]
        public string PostCode { get; set; }

        [Required]
        public string PostCity { get; set; }
    }
}
