namespace EngineeringSoftwareLicensingTracker.Services.Worker

    // Licencje imienne przypisane do jednego pracownika
{
    public class NameLicenseService : LicenseService
    {

        public Boolean WorkerIDCheck(int assignedID, int workerID)
        {

            if (assignedID <= 0)
            {
                throw new ArgumentException("The ID is not correct.");
            }

            if (assignedID == workerID)
            {
                return true;
            }
            else return false;
        }

        public Boolean LimitCheck(int noOfActiveReservation, int limit)
        {

            if (noOfActiveReservation < 0 || limit <= 0)
            {
                throw new ArgumentException("There is an existing data error.");
            }

            if (noOfActiveReservation < limit)
            {
                return true;
            }
            return false;
        }

    }
}
