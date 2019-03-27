using FVat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static async Task AddNewVATAsync(VAT vat)
        {
            try
            {
                var context = new AppDBContext();
                context.Entry(vat.Issuer).State = EntityState.Unchanged;
                context.Entry(vat.Receiver).State = EntityState.Unchanged;
                context.VATs.Add(vat);
                await context.SaveChangesAsync();
            }
            catch { throw; }
        }

        public static async Task ModifyVATAsync(VAT vat)
        {
            try
            {
                var context = new AppDBContext();
                var target = await context.VATs.FindAsync(vat.Id);

                if (target == null)
                    throw new KeyNotFoundException();

                target.Update(vat);
                context.Entry(target).State = EntityState.Modified;
                context.Entry(vat.Issuer).State = EntityState.Unchanged;
                context.Entry(vat.Receiver).State = EntityState.Unchanged;

                await context.SaveChangesAsync();
            }
            catch { throw; }
        }
    }
}
