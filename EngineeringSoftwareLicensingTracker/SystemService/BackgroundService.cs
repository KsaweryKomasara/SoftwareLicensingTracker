using EngineeringSoftwareLicensingTracker.Entities;
namespace EngineeringSoftwareLicensingTracker.SystemService
{
    public class BackgroundService
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
        public async Task<bool> ShouldBeReleased(LicenseEntity license) // When the user opens the app
        {
            if ((DateTime.Now - license.ActivationDate).TotalHours > 8)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ShouldBeReleasedSoon(LicenseEntity license)
        {
            double minutesLeft = (DateTime.Now - license.ActivationDate).TotalMinutes;
            if ((minutesLeft <= 60 && minutesLeft > 0))
            {
                return true;
            }
            return false;
        }

    }
}
