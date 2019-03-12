using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jant.Entities;

namespace Jant.Dal.Concrete.EntityFramework
{
    public class JantDataContext:DbContext
    {
        public DbSet<Marka> Markas { get; set; }

        public DbSet<Urun> Uruns { get; set; }

        public DbSet<Resim> Resims { get; set; }

        public DbSet<Kategori> Kategoris { get; set; }

        public DbSet<Uye> Uyes { get; set; }

        public DbSet<Sepet> Sepets { get; set; }

        public DbSet<SepettekiUrunler> SepettekiUrunler { get; set; }

        public DbSet<Test> TabloTest { get; set; }

        public JantDataContext()
            : base("JantDataContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<JantDataContext>());
        }
    }
}
