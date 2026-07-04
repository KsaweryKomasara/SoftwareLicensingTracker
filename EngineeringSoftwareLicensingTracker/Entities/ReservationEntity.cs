namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class ReservationEntity
    {
        public int Id { get; set; }
        public String ReservationName { get; set; }
        public String ReservationDate { get; set; }
        public String ReleaseDate { get; set; }
        public int WorkerID { get; set; }
    }
}
