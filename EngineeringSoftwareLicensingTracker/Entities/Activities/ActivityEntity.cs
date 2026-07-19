namespace EngineeringSoftwareLicensingTracker.Entities.Activities
{
    public class ActivityEntity
    {
        public Guid Id { get; set; }
        public int? WorkerEntityId { get; set; }
        public WorkerEntity WorkerEntity { get; set; }
        public DateTime DateTime { get; set; }
        public ActivityStatus Status { get; set; }
        public enum ActivityStatus
        {
            SUCCES, QUEUE, NOAVAILABLESLOTS, LICENSEEXPIRED, OTHER
        }
        public ActivityName Name { get; set;  }
        public enum ActivityName
        {
            RSERVELICENSE, RELEASELICENSE, EXTENDLICENSE
        }
        public ActivityEntity setStatus(ActivityStatus status)
        {
            this.Status = status;
            return this;
        }
    }
}
