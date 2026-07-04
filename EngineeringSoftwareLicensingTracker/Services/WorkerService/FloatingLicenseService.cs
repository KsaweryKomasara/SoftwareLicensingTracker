using EngineeringSoftwareLicensingTracker.DataBase;
namespace EngineeringSoftwareLicensingTracker.Services.WorkerService

// Licencje sieciowe
{
    public class FloatingLicenseService : LicenseService
    {

        public FloatingLicenseService(AppDbContext appDbContext) : base(appDbContext) { }
        public Boolean Check(int noOfActiveReservation, int limit)
        {

            if (noOfActiveReservation < 0 || limit <= 0)
            {
                throw new ArgumentException("There is an existing data error");
            }

            if (noOfActiveReservation < limit)
            {
                return true;
            }
            return false;
        }
    }
}
