using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    sealed class VATEntity: Addressable, IUpdateable<VATEntity>
    {
        [StringLength(14, MinimumLength = 10)]
        public string NIP { get; set; }

        public string NIPTextFormatted
        {
            get
            {
                if (NIP.Length < 10)
                    throw new Exception("NIP string is to short.");

                return $"{NIP.Substring(0, 3)}-{NIP.Substring(3, 3)}-{NIP.Substring(6, 2)}-{NIP.Substring(8, 2)}";
            }
        }

        [StringLength(11, MinimumLength = 11)]
        public string PESEL { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public void Update(VATEntity source)
        {
            Id = source.Id;
            Name = source.Name;
            NIP = source.NIP;
            PESEL = source.PESEL;
            EMail = source.EMail;
            PhoneNumber = source.PhoneNumber;
            Street = source.Street;
            ParcelNumber = source.ParcelNumber;
            PostCode = source.PostCode;
            PostCity = source.PostCity;
        }
    }
}
