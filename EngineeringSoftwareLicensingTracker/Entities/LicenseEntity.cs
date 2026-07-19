namespace EngineeringSoftwareLicensingTracker.Entities
{
    public class LicenseEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public enum LicenseType
        {
            FLOATING, NAME, NODELOCKED 
        }
        public LicenseType Type { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUsedDate { get; set; }
        public int TotalSlots { get; set; }
        public int SlotsOccupied { get; set; }

    }
}
