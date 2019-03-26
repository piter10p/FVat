using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    class VAT: BasicEntity
    {
        [ForeignKey("Issuer")]
        public int? IssuerId { get; set; }
        public virtual VATEntity Issuer { get; set; }

        [ForeignKey("Receiver")]
        public int? ReceiverId { get; set; }
        public virtual VATEntity Receiver { get; set; }
    }
}
