namespace EngineeringSoftwareLicensingTracker.Entities.Programs
{
    public class NodeLockedLicense : LicenseEntity
    {
        public String Localization { get; set; }
        public int? WorkplaceId { get; set; }
        public WorkplaceEntity WorkplaceEntity { get; set; }
        public int PrimaryUserID { get; set; }
        public int TotalSlots { get; set; } = 1;
    }
}
