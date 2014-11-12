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
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }
        
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

        public class TripConfiguration :
            EntityTypeConfiguration<Trip>
        {
            public TripConfiguration()
            {
                HasKey(t => t.Identifier);
            }
        }

        public class PersonConfiguration :
            EntityTypeConfiguration<Person>
        {
            public PersonConfiguration()
            {
                
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DestinationConfiguration());
            modelBuilder.Configurations.Add(new LodgingConfiguration());
            modelBuilder.Configurations.Add(new TripConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
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
      
//    modelBuilder.Entity<Trip>().HasKey(t => t.Identifier)
         
//}