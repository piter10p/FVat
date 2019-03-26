using FVat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.DAL
{
    class VATsManager
    {
        public static IEnumerable<VAT> GetEntities()
        {
            try
            {
                var context = new AppDBContext();
                return context.VATs.Include("Issuer").Include("Receiver").ToArray();
            }
            catch { throw; }
        }

        public static async Task RemoveVATAsync(VAT vat)
        {
            try
            {
                var context = new AppDBContext();
                var query = from v in context.VATs where v.Name == vat.Name select v;

                foreach (var v in query)
                {
                    context.VATs.Remove(v);
                }

                await context.SaveChangesAsync();
            }
            catch { throw; }
        }
    }
}
