using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FVat.Models;

namespace FVat.DAL
{
    class AppDBContext: DbContext
    {
        public AppDBContext(): base("DefaultConnection") {}

        public DbSet<VATEntity> VATEntities { get; set; }
        public DbSet<VATItem> VATItems { get; set; }
        public DbSet<VAT> VATs { get; set; }
        public DbSet<ItemOfVAT> ItemsOfVATs { get; set; }
    }
}
