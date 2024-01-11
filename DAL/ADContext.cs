using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUTODEALERN.Model;


namespace AUTODEALERN.DAL
{
    internal class ADContext : DbContext
    {
      public ADContext() : base("AD")
        {
            //Database.SetInitializer<ADContext>(new DropCreateDatabaseIfModelChanges<ADContext>());
            Database.SetInitializer(new ADInitializer());
        }
        public DbSet<Salesman> SalesmanDb { get; set; }
        public DbSet<MenuItem> MenuItemDb { get; set; }
        public DbSet<Order> OrderDb { get; set; }
        public DbSet<Client> ClientDb { get; set; }

    }
}
