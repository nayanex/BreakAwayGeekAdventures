using DataLayer;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity.Validation;
//using System.Diagnostics;

namespace BreakAwayConsole
{
    class Program
    {
        private static void InsertDestination()
        {
            var destination = new Destination
            {
                Country = "Indonesia",
                Description = "EcoTourism at its best in exquisite Bali",
                Name = "Bali"
            };

            using (var context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }

        private static void InsertTrip()
        {
            var trip = new Trip()
            {
                costUSD = 800,
                StartDate = new DateTime(2011, 9, 1),
                EndDate = new DateTime(2011, 9, 14)
            };
            using (var context = new BreakAwayContext())
            {
                context.Trips.Add(trip);
                context.SaveChanges();
            }
        }

        private static void InsertPerson()
        {
            var person = new Person()
            {
                FirstName = "Rowan",
                LastName = "Miller",
                SocialSecurityNumber = 12345678
            };
            using (var context = new BreakAwayContext())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<BreakAwayContext>());

            InsertDestination();
            InsertTrip();
            InsertPerson();

        }
    }
}
