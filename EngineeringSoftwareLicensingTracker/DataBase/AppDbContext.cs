using Microsoft.EntityFrameworkCore;
using EngineeringSoftwareLicensingTracker.Entities;
using EngineeringSoftwareLicensingTracker.Entities.Activities;

namespace EngineeringSoftwareLicensingTracker.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<LicenseEntity> LicenseEntity { get; set; }
        public DbSet<ReservationEntity> Reservations {  get; set; }
        public DbSet<WorkerEntity> WorkerEntity { get; set; }
        public DbSet<Activity> Activity { get; set; }
    }
}
