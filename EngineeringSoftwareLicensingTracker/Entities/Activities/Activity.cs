namespace EngineeringSoftwareLicensingTracker.Entities.Activities
{
    public class Activity
    {
        public Guid ActivityID { get; set; }
        public String ActivityName { get; set; }
        public int WorkerID { get; set; }
        public ActivityStatus.ActivityID ActvityStatusID {  get; set; }
    }
}
