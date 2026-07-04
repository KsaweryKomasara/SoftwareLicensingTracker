using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Entities;
using EngineeringSoftwareLicensingTracker.Entities.Activities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
namespace EngineeringSoftwareLicensingTracker.Services.WorkerService
{

    public abstract class LicenseService
    {
        public AppDbContext AppDbContext { get; set; }

        public LicenseService(AppDbContext AppDbContext) 
        { 
            this.AppDbContext = AppDbContext;
        }

        private ActivityStatus ValidateReservation(LicenseEntity license)
        {
            if (license.TotalSlots < 0)
            {
                throw new ArgumentException("Incorret total slots number");
            }

            if (license.TotalSlots - license.SlotsOccupied < 1)
            {
                return ActivityStatus.NOAVAIBLESLOTS;
            }

            if (license.TotalSlots - license.SlotsOccupied > 1)
            {
                return ActivityStatus.SUCCES;
            }

            return ActivityStatus.OTHER;
        }

        private ActivityStatus ValidateReleasation(LicenseEntity license)
        {

            if (license.TotalSlots < 0)
            {
                throw new ArgumentException("Incorrect total slots number.");
            }

            if (license.SlotsOccupied <= 0)
            {
                return ActivityStatus.NOAVAIBLESLOTS;
            }

            if (license.SlotsOccupied > 0)
            {
                license.SlotsOccupied -= 1;
                return ActivityStatus.SUCCES;
            }

            return ActivityStatus.OTHER;

        }

        public async Task<Activity> Reserve(LicenseEntity license, WorkerEntity worker)
        {

            Activity activity = new Activity();

            activity.ActivityName = "License Reserve";
            activity.WorkerID = worker.Id;
            activity.ActvityStatus = this.ValidateReservation(license);
            return activity;

        }

        public async Task<Activity> ReleaseLicense(LicenseEntity license, WorkerEntity worker)
        {
            Activity activity = new Activity();

            activity.ActivityName = "License Release";
            activity.WorkerID = worker.Id;
            activity.ActvityStatus = this.ValidateReleasation(license);
            return activity;
        }

        public async Task<bool> ExtendLicenseReservation(LicenseEntity license)
        {
            license.ActivationDate = DateTime.Now;
            return true;
        }
}
}

