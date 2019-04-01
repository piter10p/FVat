using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    class Price: ICloneable
    {
        public double Net { get; set; } = 0;
        public double Gross { get; set; } = 0;
        public double VAT { get; set; } = 0;

        public string NetText
        {
            get
            {
                return Net.ToString("C");
            }
        }

        public string GrossText
        {
            get
            {
                return Gross.ToString("C");
            }
        }

        public string VATText
        {
            get
            {
                return VAT.ToString("C");
            }
        }

        public static Price operator + (Price a, Price b)
        {
            var result = a.MemberwiseClone() as Price;

            result.Net += b.Net;
            result.Gross += b.Gross;
            result.VAT += b.VAT;

            return result;
        }

        public Price() { }

        public Price(double net, double amount, VATRate vatRate)
        {
            Net = net * amount;
            Gross = amount * net * CalculateVATMultipler(vatRate);
            VAT = Gross - Net;
        }

        private double CalculateVATMultipler(VATRate vatRate)
        {
            if (vatRate == VATRate.RateZW)
                return 1;

            return (double)vatRate / 100 + 1;
        }

        object ICloneable.Clone()
        {
            var output = new Price();
            output.Net = this.Net;
            output.Gross = this.Gross;
            output.VAT = this.VAT;

            return output;
        }
    }
}
