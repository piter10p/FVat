using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.DAL
{
    static class VATEntitiesManager
    {
        public static IEnumerable<VATEntity> GetEntities()
        {
            try
            {
                var context = new AppDBContext();
                return context.VATEntities.ToArray();
            }
            catch { throw;  }
        }

        public static async Task RemoveEntityAsync(VATEntity entity)
        {
            try
            {
                var context = new AppDBContext();
                var query = from e in context.VATEntities where e.Name == entity.Name select e;

                foreach(var e in query)
                {
                    context.VATEntities.Remove(e);
                }

                await context.SaveChangesAsync();
            }
            catch { throw; }
        }
    }
}
