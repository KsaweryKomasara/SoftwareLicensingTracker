using EngineeringSoftwareLicensingTracker.DataBase;
namespace EngineeringSoftwareLicensingTracker.Services.ManagerService
{
    public class Activity
    {
        public AppDbContext AppDbContext { get; set; }
        public Activity (AppDbContext dbContext)
        {
            AppDbContext = dbContext;
        }

    }
}
