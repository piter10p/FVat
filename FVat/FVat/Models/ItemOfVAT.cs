using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    class ItemOfVAT : BasicEntity, IUpdateable<ItemOfVAT>
    {
        [NotMapped]
        public override string Name
        {
            get
            {
                if (VATItem == null)
                    return "";

                return VATItem.Name;
            }
        }

        [Required]
        public double Amount { get; set; }

        [Required, ForeignKey("VATItem")]
        public int VATItemId { get; set; }
        public virtual VATItem VATItem { get; set; }

        [Required, ForeignKey("VAT")]
        public int VATId { get; set; }
        public virtual VAT VAT { get; set; }

        [NotMapped]
        public double NetPrice
        {
            get
            {
                return Amount * VATItem.UnitPrice;
            }
        }

        [NotMapped]
        public string NetPriceText
        {
            get
            {
                return NetPrice.ToString("C");
            }
        }

        [NotMapped]
        public double GrossPrice
        {
            get
            {
                return Amount * VATItem.UnitPrice * VATItem.VATMultipler;
            }
        }

        [NotMapped]
        public string GrossPriceText
        {
            get
            {
                return GrossPrice.ToString("C");
            }
        }

        [NotMapped]
        public double VATPrice
        {
            get
            {
                return GrossPrice - NetPrice;
            }
        }

        [NotMapped]
        public string VATPriceText
        {
            get
            {
                return VATPrice.ToString("C");
            }
        }

        public void Update(ItemOfVAT source)
        {
            this.Id = source.Id;
            this.Amount = source.Amount;

            this.VATItemId = source.VATItemId;
            this.VATItem = source.VATItem;

            this.VATId = source.VATId;
            this.VAT = source.VAT;
        }
    }
}
