using FVat.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    class VATItem: BasicEntity, IUpdateable<VATItem>
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
                var converter = new EnumDescriptionTypeConverter(typeof(Unit));
                return converter.ConvertToInvariantString(Unit);
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

        public void Update(VATItem source)
        {
            this.Id = source.Id;
            this.Name = source.Name;
            this.Unit = source.Unit;
            this.UnitPrice = source.UnitPrice;
            this.VATRate = source.VATRate;
        }
    }
}
