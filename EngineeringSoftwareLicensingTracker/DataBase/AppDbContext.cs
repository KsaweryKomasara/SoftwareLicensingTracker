using EngineeringSoftwareLicensingTracker.Entities;
using EngineeringSoftwareLicensingTracker.Entities.Activities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EngineeringSoftwareLicensingTracker.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<LicenseEntity> Licenses { get; set; }
        public DbSet<WorkplaceEntity> Workplaces {  get; set; }
        public DbSet<WorkerEntity> Workers { get; set; }
        public DbSet<ActivityEntity> Activities { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActivityEntity>().Property(e => e.Name).HasConversion<String>();
            modelBuilder.Entity<ActivityEntity>().Property(e => e.Status).HasConversion<String>();
            modelBuilder.Entity<LicenseEntity>().Property(e => e.Type).HasConversion<String>();

        }
    }
}
