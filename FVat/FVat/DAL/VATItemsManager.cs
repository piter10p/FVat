using System;
using System.Collections.Generic;
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
    }
}
