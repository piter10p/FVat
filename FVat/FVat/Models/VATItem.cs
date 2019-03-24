using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    sealed class VATItem: BasicEntity
    {
        [Required]
        public Unit Unit { get; set; }

        [Required]
        public VATRate VATRate { get; set; }

        [Required, DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        [NotMapped]
        public string UnitText
        {
            get
            {
                return UnitConverter.ToString(Unit);
            }
        }

        [NotMapped]
        public string PriceText
        {
            get
            {
                return UnitPrice.ToString("C");
            }
        }
    }
}
