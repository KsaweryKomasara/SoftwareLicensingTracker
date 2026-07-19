namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public int? WorkerEntityId{ get; set; }
        public WorkerEntity WorkerEntity { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
