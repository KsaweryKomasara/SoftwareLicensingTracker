using EngineeringSoftwareLicensingTracker.Entities.Activities;
using EngineeringSoftwareLicensingTracker.Entities.LicenceType;

namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class WorkerEntity
    {
        public int WorkerEntityId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String RoomName { get; set; }
        public int Number { get; set; }
        public WorkplaceEntity WorkplaceEntity { get; set; }
        public ICollection<NameLicense> NameLicenses { get; set; } 
        public ICollection<Activity> Activities { get; set; }
    }
}
