using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    class VATEntity: Addressable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string NIP { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string PESEL { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
