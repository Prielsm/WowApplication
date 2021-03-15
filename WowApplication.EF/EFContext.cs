using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowApplication.EF.Model;

namespace WowApplication.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : base("WowApplication")
        {
            Database.SetInitializer<EFContext>(new CreateDatabaseIfNotExists<EFContext>());
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Encounter> Encounters { get; set; }
    }
}
