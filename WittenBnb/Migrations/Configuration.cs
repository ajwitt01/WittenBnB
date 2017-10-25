using WittenBnb.Models;
using System.Data.Entity.Migrations;

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
            new Reservation { Id = 1, FirstName = "John", LastName = "Smith", Email = "jsmith@example.com", Phone = "207-555-0150", Notes = "I like my eggs runny." },
            new Reservation { Id = 2, FirstName = "Abigail", LastName = "Pumzan", Email = "apumzan@fineartschool.net", Phone = "225-555-0185", Notes = "Real name is actually Adam." },
            new Reservation { Id = 3, FirstName = "Herkus", LastName = "Zuzana", Email = "hzuzana@domain.net", Phone = "603-555-0115", Notes = "Weird guy, but tips well." },
            new Reservation { Id = 4, FirstName = "Borivoi", LastName = "Carlos", Email = "bcarlos@adatum.com", Phone = "605-555-0132", Notes = "Works at a shell company for a popular software company." },
            new Reservation { Id = 5, FirstName = "Ulisses", LastName = "Ingomar", Email = "ingomar@toastersrus.com", Phone = "360-555-0123", Notes = "Pronounced \"Ooohlissus\", not like Ulysses S. Grant. Let's not make that mistake again." },
            new Reservation { Id = 6, FirstName = "Azel", LastName = "Birger", Email = "abirger@whoknowswhat.com", Phone = "609-555-0184", Notes = "On honeymoon." },
            new Reservation { Id = 7, FirstName = "Okoro", LastName = "Ritu", Email = "oritu@notyouraveragelocalhost.local", Phone = "410-555-0150", Notes = "Threatened to host a manga convention in his room." },
            new Reservation { Id = 8, FirstName = "Pericles", LastName = "", Email = "designer@parthenon.com", Phone = "601-555-0199", Notes = "VIP. Keep him away from the Peloponnesians." },
            new Reservation { Id = 9, FirstName = "Christmas", LastName = "Regina", Email = "winterqueen@cohowinery.com", Phone = "518-555-0129", Notes = "Winter must be coming." }
            );
        }
    }
}
