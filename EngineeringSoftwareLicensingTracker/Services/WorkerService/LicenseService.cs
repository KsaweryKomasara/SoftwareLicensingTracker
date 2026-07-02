using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Entities;
using EngineeringSoftwareLicensingTracker.Entities.Activities;
using Microsoft.AspNetCore.Mvc;
namespace EngineeringSoftwareLicensingTracker.Services.WorkerService
{

    public abstract class LicenseService
    {
        public AppDbContext AppDbContext { get; set; }
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

        public async Task<Activity> ReleaseLicense(License license, Entities.Worker worker)
        {
            Activity activity = new Activity();

            activity.ActivityName = "License Release";
            activity.WorkerID = worker.WorkerID;

            if (license.SlotsOccupied < 0 || license.TotalSlots < 0)
            {
                activity.ActvityStatusID = ActivityStatus.ActivityID.NOAVAIBLESLOTS;
                return activity;
            }

            if (license.SlotsOccupied > 0)
            {
                license.SlotsOccupied -= 1;
                activity.ActvityStatusID = ActivityStatus.ActivityID.SUCCES;
                return activity;
            }

            activity.ActvityStatusID = ActivityStatus.ActivityID.OTHER;
            return activity;
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

