using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }

        public class DestinationConfiguration :
            EntityTypeConfiguration<Destination>
        {
            public DestinationConfiguration()
            {
                Property(d => d.Name).IsRequired();
                Property(d => d.Description).HasMaxLength(500);
                Property(d => d.Photo).HasColumnType("image");
            }
        }

        public class LodgingConfiguration :
            EntityTypeConfiguration<Lodging>
        {
            public LodgingConfiguration()
            {
                Property(l => l.Name).IsRequired().HasMaxLength(200);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DestinationConfiguration());
            modelBuilder.Configurations.Add(new LodgingConfiguration());
        }

    }
}


//protected override void OnModelCreating(DbModelBuilder modelBuilder)
//{
//    modelBuilder.Entity<Destination>()
//        .Property(d => d.Name).IsRequired();
//    modelBuilder.Entity<Destination>()
//        .Property(d => d.Description).HasMaxLength(500);
//    modelBuilder.Entity<Destination>()
//        .Property(d => d.Photo).HasColumnType("image");

//    modelBuilder.Entity<Lodging>()
//        .Property(l => l.Name).IsRequired().HasMaxLength(200);
//}