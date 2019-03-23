using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string ParcelNumber { get; set; }

        [Required, DataType(DataType.PostalCode)]
        public string PostCode { get; set; }

        [Required]
        public string PostCity { get; set; }

        [NotMapped]
        public string FullAddressFormatted
        {
            get
            {
                try
                {
                    return $"{Street} {ParcelNumber}\n{PostCode[0]}{PostCode[1]}-{PostCode[2]}{PostCode[3]}{PostCode[4]} {PostCity}";
                }
                catch { throw; }
            }
        }
    }
}
