namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class License
    {
        public String Name { get; set; }
        public String PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReservationID { get; set; }
        public int TotalSlots { get; set; }
        public int SlotsOccupied { get; set; }

    }
}
