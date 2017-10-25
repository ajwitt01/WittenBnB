using WittenBnb.Models;
using System.Data.Entity;

namespace WittenBnb
{
    public class WittenBnbContext : DbContext
    {
        public WittenBnbContext() : base("name=WittenBnbContext") { }

        public virtual DbSet<Reservation> Reservations { get; set; }
    }
}