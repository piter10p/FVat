using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    sealed class VATItem: BasicEntity
    {
        [Required]
        public double Amount { get; set; }

        [Required]
        public Unit Unit { get; set; }

        [Required]
        public VATRate VATRate { get; set; }

        [Required, DataType(DataType.Currency)]
        public double UnitPrice { get; set; }
    }
}
