using EngineeringSoftwareLicensingTracker.Entities.Programs;

namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class WorkplaceEntity
    {
        public int WorkplaceId { get; set; }
        public String RoomName { get; set; }
        public ICollection<NodeLockedLicense> NodeLockedLicenses { get; set; }
        public int? WorkerEntityId { get; set; }
        public WorkerEntity WorkerEntity { get; set; }
    }
}
