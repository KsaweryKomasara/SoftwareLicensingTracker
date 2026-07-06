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
        public DbSet<LicenseEntity> Licenses { get; set; }
        public DbSet<WorkplaceEntity> Workplaces {  get; set; }
        public DbSet<WorkerEntity> Workers { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
