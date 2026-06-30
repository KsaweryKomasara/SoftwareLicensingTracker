namespace EngineeringSoftwareLicensingTracker.Services.Worker
{
    public class LicenseService
    {
        public int ReturnTimeToExpire(DateTime actualDate, DateTime expirationDate)
        {
            return (expirationDate - actualDate).Days;
        }

        public Boolean HasExpired(int days)
        {

            if (days > 3650)
            {
                throw new ArgumentException("License lasts too long");
            }

            if (days < 0)
            {
                return true;
            }
            else return false;
        }

    }
}
