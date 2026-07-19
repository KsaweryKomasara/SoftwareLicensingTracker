using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Entities;
using EngineeringSoftwareLicensingTracker.Entities.Activities;
using EngineeringSoftwareLicensingTracker.Services.ManagerService;
using EngineeringSoftwareLicensingTracker.Common.Exception;
using EngineeringSoftwareLicensingTracker.Common.Result.Result;
namespace EngineeringSoftwareLicensingTracker.Services.WorkerService
{

    public class LicenseService
    {
        public AppDbContext AppDbContext { get; set; }
        private readonly ActivityService ActivityService;

        public LicenseService(AppDbContext AppDbContext) 
        { 
            this.AppDbContext = AppDbContext;
            this.ActivityService = new ActivityService(this.AppDbContext);
        }

        private Result ValidateReservation(LicenseEntity license)
        {
            if (license == null)
            {
                throw new NotFoundResourceException();
            }
            if (license.TotalSlots < 0)
            {
                throw new ArgumentException("Incorret total slots number");
            }

            if (license.TotalSlots - license.SlotsOccupied < 1)
            {
                return Result.Failure(ResultCode.NOAVAILABLESLOTS);
            }

            if (license.TotalSlots - license.SlotsOccupied > 1)
            {
                license.SlotsOccupied += 1;
                return Result.Succes();
            }

            return Result.Failure(ResultCode.OTHER);
        }

        private Result ValidateReleasation(LicenseEntity license)
        {
            if (license == null)
            {
                throw new NotFoundResourceException();
            }
            if (license.TotalSlots < 0)
            {
                throw new ArgumentException("Incorrect total slots number.");
            }

            if (license.SlotsOccupied <= 0)
            {
                return Result.Failure(ResultCode.NOAVAILABLESLOTS);
            }

            if (license.SlotsOccupied > 0)
            {
                license.SlotsOccupied -= 1;
                return Result.Succes();
            }

            return Result.Failure(ResultCode.OTHER);

        }

        private Result ValidateExtension(LicenseEntity license)
        {
            if (license == null)
            {
                throw new NotFoundResourceException();
            }
            if (license == null)
            {
                return Result.Failure(ResultCode.LICENSEEXPIRED);
            }

            return Result.Succes();
        }

        public async Task<Result> Reserve(int licenseId, int workerId)
        {
            var license = await AppDbContext.Licenses.FindAsync(licenseId);
            var worker = await AppDbContext.Workers.FindAsync(workerId);
            Result result = this.ValidateReservation(license);
            Reservation reservation = new Reservation();
            reservation.WorkerEntityId = workerId;
            reservation.ReservationDate = DateTime.Now;
            // license.Reservations.Add(reservation);
            await this.ActivityService.createNewActivity(ActivityEntity.ActivityName.RSERVELICENSE, result, workerId);
            return result;

        }

        public async Task<Result> Release(int licenseId, int workerId)
        {
            var license = await AppDbContext.Licenses.FindAsync(licenseId);
            var worker = await AppDbContext.Workers.FindAsync(workerId);
            Result result = this.ValidateReleasation(license);
            await this.ActivityService.createNewActivity(ActivityEntity.ActivityName.RELEASELICENSE, result, workerId);
            return result;

        }

        public async Task<Result> ExtendLicenseReservation(int licenseId, int workerId)
        {
            var license = await AppDbContext.Licenses.FindAsync(licenseId);
            var worker = await AppDbContext.Workers.FindAsync(workerId);
            Result result = this.ValidateExtension(license);
            await this.ActivityService.createNewActivity(ActivityEntity.ActivityName.EXTENDLICENSE, result, workerId);
            return result;
        }

        public async Task AddNewLicense(LicenseEntity licenseEntity)
        {
            this.AppDbContext.Licenses.Add(licenseEntity);
            await this.AppDbContext.SaveChangesAsync();
        }

    }
}

