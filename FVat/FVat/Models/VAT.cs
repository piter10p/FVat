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

        [Required]
        public string PlaceOfIssue { get; set; }

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

        [NotMapped]
        public string DateOfServiceText
        {
            get
            {
                return DateOfService.ToShortDateString();
            }
        }


        [DataType(DataType.Date)]
        public DateTime? DateOfPayment { get; set; }

        [NotMapped]
        public string DateOfPaymentText
        {
            get
            {
                if (DateOfPayment == null)
                    return "Brak";

                return DateOfPayment.Value.ToShortDateString();
            }
        }

        [DataType(DataType.Date)]
        public DateTime? PaymentTermDate { get; set; }

        [NotMapped]
        public string PaymentTermDateText
        {
            get
            {
                if (PaymentTermDate == null)
                    return "Brak";

                return PaymentTermDate.Value.ToShortDateString();
            }
        }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public DeliveryMethod DeliveryMethod { get; set; }

        [NotMapped]
        public Price Price
        {
            get
            {
                var price = new Price();

                var items = DAL.ItemsOfVATsManager.GetItemsofVAT(this);

                foreach (var i in items)
                {
                    var itemPrice = i.Price;

                    price.Net += itemPrice.Net;
                    price.Gross += itemPrice.Gross;
                    price.VAT += itemPrice.VAT;
                }

                return price;
            }
        }

        public void Update(VAT source)
        {
            Id = source.Id;
            Name = source.Name;
            PlaceOfIssue = source.PlaceOfIssue;

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
