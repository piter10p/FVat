using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        //DATES
        [Required, DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; } = DateTime.Now;

        [NotMapped]
        public string DateOfIssueText
        {
            get
            {
                return DateOfIssue.ToShortDateString();
            }
        }

        [Required, DataType(DataType.Date)]
        public DateTime DateOfService { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? DateOfPayment { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PaymentTermDate { get; set; }

        public void Update(VAT source)
        {
            Id = source.Id;
            Name = source.Name;

            ReceiverId = source.ReceiverId;
            Receiver = source.Receiver;

            IssuerId = source.IssuerId;
            Issuer = source.Issuer;

            DateOfIssue = source.DateOfIssue;
            DateOfService = source.DateOfService;
            DateOfPayment = source.DateOfPayment;
            PaymentTermDate = source.PaymentTermDate;
        }
    }
}
