namespace EngineeringSoftwareLicensingTracker.Entities.LicenceType
{
    public class NameLicense : LicenseEntity
    {
        public int? WorkerEntityId { get; set; }
        public WorkerEntity WorkerEntity { get; set; }
        public String UserCloudLogin { get; set; }
        public int DeviceLimit { get; set; }
        public int TotalSlots { get; set; } = 1;
    }
}
