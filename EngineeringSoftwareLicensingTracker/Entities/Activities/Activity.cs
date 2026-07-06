namespace EngineeringSoftwareLicensingTracker.Entities.Activities
{
    public class Activity
    {
        public Guid ActivityId { get; set; }
        public String ActivityName { get; set; }
        public int? WorkerEntityId { get; set; }
        public WorkerEntity WorkerEntity { get; set; }
        public ActivityStatus ActvityStatus {  get; set; }
    }
}
