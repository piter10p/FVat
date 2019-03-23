using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVat.DAL
{
    class AppDBContext: DbContext
    {
        public AppDBContext(): base("DefaultConnection") {}
    }
}
