using EngineeringSoftwareLicensingTracker.Entities;
using Microsoft.AspNetCore.Mvc;
namespace EngineeringSoftwareLicensingTracker.Services.Worker
{

    public abstract class LicenseService
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

        public async Task<bool> ReleaseLicense(License license)
        {

            if (license.SlotsOccupied < 0 || license.TotalSlots < 0)
            {
                return false;
            }

            if (license.SlotsOccupied > 0)
            {
                license.SlotsOccupied -= 1;
            }

            return true;
        }

        public async Task<bool> CheckToRelease(License license) // When the user opens the app
        {
            if ((DateTime.Now - license.ActivationDate).TotalHours > 8)
            {
                await this.ReleaseLicense(license);
            }

            return false;
        }

        public async Task<bool> ReleaseAlert(License license)
        {
            double minutesLeft = (DateTime.Now - license.ActivationDate).TotalMinutes;
            if ((minutesLeft <= 60 && minutesLeft > 0))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExtendLicenseReservation(License license)
        {
            license.ActivationDate = DateTime.Now;
            return true;
        }

    }
}

