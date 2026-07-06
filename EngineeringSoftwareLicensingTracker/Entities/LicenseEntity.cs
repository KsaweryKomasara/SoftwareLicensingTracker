namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class LicenseEntity
    {
        public int LicenseId { get; set; }
        public String Name { get; set; }
        public String PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUsedDate { get; set; }
        public int TotalSlots { get; set; }
        public int SlotsOccupied { get; set; }

    }
}
