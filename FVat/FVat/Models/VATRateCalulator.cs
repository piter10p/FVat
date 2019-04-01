using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.Models
{
    class VATRateCalulator
    {
        List<KeyValuePair<VATRate, Price>> pricesList;
        IEnumerable<ItemOfVAT> itemsOfVAT;

        public List<KeyValuePair<VATRate, Price>> Calulate(VAT vat)
        {
            try
            {
                pricesList = new List<KeyValuePair<VATRate, Price>>();
                itemsOfVAT = DAL.ItemsOfVATsManager.GetItemsofVAT(vat);

                foreach(var item in itemsOfVAT)
                {
                    AddItemToPricesList(item);
                }

                return pricesList;
            }
            catch
            {
                throw;
            }
        }

        private void AddItemToPricesList(ItemOfVAT item)
        {
            var price = item.Price;

            var listElement = GetPriceFromList(item.VATItem.VATRate);
            listElement.Value.Net += price.Net;
            listElement.Value.Gross += price.Gross;
            listElement.Value.VAT += price.VAT;
        }

        private KeyValuePair<VATRate, Price> GetPriceFromList(VATRate rate)
        {
            foreach(var e in pricesList)
            {
                if (e.Key == rate)
                    return e;
            }

            var price = new Price();
            var listElement = new KeyValuePair<VATRate, Price>(rate, new Price());
            pricesList.Add(listElement);
            return listElement;
        }
    }
}
