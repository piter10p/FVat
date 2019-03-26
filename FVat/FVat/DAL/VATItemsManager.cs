using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.DAL
{
    static class VATItemsManager
    {
        public static IEnumerable<VATItem> GetItems()
        {
            try
            {
                var context = new AppDBContext();
                return context.VATItems.ToArray();
            }
            catch { throw; }
        }

        public static async Task RemoveItemAsync(VATItem item)
        {
            try
            {
                var context = new AppDBContext();
                var query = from i in context.VATItems where i.Name == item.Name select i;

                foreach (var i in query)
                {
                    context.VATItems.Remove(i);
                }

                await context.SaveChangesAsync();
            }
            catch { throw; }
        }

        public static async Task AddNewItemAsync(VATItem item)
        {
            try
            {
                var context = new AppDBContext();
                context.VATItems.Add(item);
                await context.SaveChangesAsync();
            }
            catch { throw; }
        }

        public static async Task ModifyItemAsync(VATItem item)
        {
            try
            {
                var context = new AppDBContext();
                var target = await context.VATItems.FindAsync(item.Id);

                if (target == null)
                    throw new KeyNotFoundException();

                target.Update(item);
                context.Entry(target).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
            catch { throw; }
        }
    }
}
