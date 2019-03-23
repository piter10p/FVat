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
    }
}
