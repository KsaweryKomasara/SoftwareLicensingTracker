namespace EngineeringSoftwareLicensingTracker.Entities.Programs
{
    public class FloatingLicense : LicenseEntity
    {
        public ICollection<WorkerEntity> WorkerEntities { get; set; }
        public String Port { get; set; }

    }
}
