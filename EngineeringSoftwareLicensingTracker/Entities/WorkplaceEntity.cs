namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class WorkplaceEntity
    {
        public int Id { get; set; }
        public String RoomName { get; set; }
        public int? WorkerEntityId { get; set; }
        public WorkerEntity WorkerEntity { get; set; }
    }
}
