using EngineeringSoftwareLicensingTracker.Entities.Activities;

namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class WorkerEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Number { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
