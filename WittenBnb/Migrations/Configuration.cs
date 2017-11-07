using WittenBnb.Models;
using System.Data.Entity.Migrations;
using System;

namespace WittenBnb.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WittenBnbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WittenBnbContext context)
        {
            context.Reservations.AddOrUpdate(
            p => p.Id,
            new Reservation { Id = 1, FirstName = "John", LastName = "Smith", Email = "jsmith@example.com", Phone = "207-555-0150", Notes = "I like my eggs runny.", CheckIn = DateTime.Parse("2017-10-01 23:59:59"), CheckOut = DateTime.Parse("2017-10-02 10:30:00") },
            new Reservation { Id = 2, FirstName = "Abigail", LastName = "Pumzan", Email = "apumzan@fineartschool.net", Phone = "225-555-0185", Notes = "Real name is actually Adam.", CheckIn = DateTime.Parse("2017-10-03"), CheckOut = DateTime.Parse("2017-10-04") },
            new Reservation { Id = 3, FirstName = "Herkus", LastName = "Zuzana", Email = "hzuzana@domain.net", Phone = "603-555-0115", Notes = "Weird guy, but tips well.", CheckIn = DateTime.Parse("2017-10-05"), CheckOut = DateTime.Parse("2017-10-06") },
            new Reservation { Id = 4, FirstName = "Borivoi", LastName = "Carlos", Email = "bcarlos@adatum.com", Phone = "605-555-0132", Notes = "Works at a shell company for a popular software company.", CheckIn = DateTime.Parse("2017-10-07"), CheckOut = DateTime.Parse("2017-10-08") },
            new Reservation { Id = 5, FirstName = "Ulisses", LastName = "Ingomar", Email = "ingomar@toastersrus.com", Phone = "360-555-0123", Notes = "Pronounced \"Ooohlissus\", not like Ulysses S. Grant. Let's not make that mistake again.", CheckIn = DateTime.Parse("2017-10-09"), CheckOut = DateTime.Parse("2017-10-10") },
            new Reservation { Id = 6, FirstName = "Azel", LastName = "Birger", Email = "abirger@whoknowswhat.com", Phone = "609-555-0184", Notes = "On honeymoon.", CheckIn = DateTime.Parse("2017-10-11"), CheckOut = DateTime.Parse("2017-10-12") },
            new Reservation { Id = 7, FirstName = "Okoro", LastName = "Ritu", Email = "oritu@notyouraveragelocalhost.local", Phone = "410-555-0150", Notes = "Threatened to host a manga convention in his room.", CheckIn = DateTime.Parse("2017-10-13"), CheckOut = DateTime.Parse("2017-10-14") },
            new Reservation { Id = 8, FirstName = "Pericles", LastName = "", Email = "designer@parthenon.com", Phone = "601-555-0199", Notes = "VIP. Keep him away from the Peloponnesians.", CheckIn = DateTime.Parse("2017-10-15"), CheckOut = DateTime.Parse("2017-10-16") },
            new Reservation { Id = 9, FirstName = "Christmas", LastName = "Regina", Email = "winterqueen@cohowinery.com", Phone = "518-555-0129", Notes = "Winter must be coming.", CheckIn = DateTime.Parse("2017-10-17"), CheckOut = DateTime.Parse("2017-10-18") }
            );
        }
    }
}
