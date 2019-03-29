using FVat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.DAL
{
    static class ItemsOfVATsManager
    {
        public static IEnumerable<ItemOfVAT> GetItemsofVAT(VAT vat)
        {
            try
            {
                var context = new DAL.AppDBContext();
                var query = from i in context.ItemsOfVATs where i.VATId == vat.Id select i;

                return query.Include("VATItem").Include("VAT").ToArray();
            }
            catch
            {
                throw;
            }
        }

        public static async Task<ItemOfVAT> AddItemOfVAT(ItemOfVAT item)
        {
            try
            {
                var context = new DAL.AppDBContext();
                var output = context.ItemsOfVATs.Add(item);
                context.Entry(item.VAT).State = EntityState.Unchanged;
                context.Entry(item.VAT.Issuer).State = EntityState.Unchanged;
                context.Entry(item.VAT.Receiver).State = EntityState.Unchanged;
                context.Entry(item.VATItem).State = EntityState.Unchanged;
                await context.SaveChangesAsync();
                return output;
            }
            catch { throw; }
        }

        public static async Task RemoveItemOfVATAsync(ItemOfVAT item)
        {
            try
            {
                var context = new AppDBContext();

                var target = await context.ItemsOfVATs.FindAsync(item.Id);

                if (target == null)
                    throw new KeyNotFoundException();

                context.ItemsOfVATs.Remove(target);

                await context.SaveChangesAsync();
            }
            catch { throw; }
        }

        public static async Task ModifyItemAsync(ItemOfVAT item)
        {
            try
            {
                var context = new AppDBContext();
                var target = await context.ItemsOfVATs.FindAsync(item.Id);

                if (target == null)
                    throw new KeyNotFoundException();

                target.Update(item);
                context.Entry(target).State = EntityState.Modified;
                context.Entry(target.VAT).State = EntityState.Unchanged;
                context.Entry(target.VATItem).State = EntityState.Unchanged;

                await context.SaveChangesAsync();
            }
            catch { throw; }
        }
    }
}
