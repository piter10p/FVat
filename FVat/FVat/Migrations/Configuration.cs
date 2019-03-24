namespace FVat.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FVat.DAL.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FVat.DAL.AppDBContext context)
        {
            FillDataBaseWithTestData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        private void FillDataBaseWithTestData(DAL.AppDBContext context)
        {
            AddTestVATEntities(context);

            context.SaveChanges();
        }

        private void AddTestVATEntities(DAL.AppDBContext context)
        {
            var testEntity1 = new Models.VATEntity() { Name = "Test VAT Entity", ParcelNumber = "12/2", PostCity = "Warszawa", PostCode = "00001", Street = "Al. Ujazdowskie", NIP = "1112223344", EMail = "test@test.test", PhoneNumber = "+48111222333" };
            var testEntity2 = new Models.VATEntity() { Name = "Test VAT Entity 2", ParcelNumber = "432", PostCity = "Poznañ", PostCode = "01163", Street = "11 Listopada", PESEL = "44051401458" };

            if (!context.VATEntities.Any(e => e.Name == testEntity1.Name))
                context.VATEntities.Add(testEntity1);

            if(!context.VATEntities.Any(e => e.Name == testEntity2.Name))
                context.VATEntities.Add(testEntity2);
        }
    }
}
