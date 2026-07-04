namespace EngineeringSoftwareLicensingTracker.Entities.Activities
{
    public class Activity
    {
        public Guid ActivityId { get; set; }
        public String ActivityName { get; set; }
        public int WorkerID { get; set; }
        public ActivityStatus ActvityStatus {  get; set; }
    }
}
