using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Entities.Activities;
using EngineeringSoftwareLicensingTracker.Common.Result.Result;
namespace EngineeringSoftwareLicensingTracker.Services.ManagerService
{
    public class ActivityService
    {
        public AppDbContext AppDbContext { get; set; }
        public ActivityService (AppDbContext dbContext)
        {
            AppDbContext = dbContext;
        }

        public async Task createNewActivity(ActivityEntity.ActivityName name, Result result, int workerId)
        {
            var activity = new ActivityEntity
            {
                WorkerEntityId = workerId,
                DateTime = DateTime.Now
            };
            activity.Status = result.Code switch
            {
                ResultCode.SUCCES => ActivityEntity.ActivityStatus.SUCCES,
                ResultCode.LICENSEEXPIRED => ActivityEntity.ActivityStatus.LICENSEEXPIRED,
                ResultCode.NOAVAILABLESLOTS => ActivityEntity.ActivityStatus.NOAVAILABLESLOTS,
                ResultCode.OTHER => ActivityEntity.ActivityStatus.OTHER,
            };
            this.AppDbContext.Activities.Add(activity);
            await this.AppDbContext.SaveChangesAsync();
 
        }

    }
}
