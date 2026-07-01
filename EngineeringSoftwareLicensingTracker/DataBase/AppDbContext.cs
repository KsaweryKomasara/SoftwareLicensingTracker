using Microsoft.EntityFrameworkCore;
using EngineeringSoftwareLicensingTracker.Entities;

namespace EngineeringSoftwareLicensingTracker.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<License> Licenses;
        public DbSet<Reservation> Reservations;
        public DbSet<Worker> Workers;
    }
}
