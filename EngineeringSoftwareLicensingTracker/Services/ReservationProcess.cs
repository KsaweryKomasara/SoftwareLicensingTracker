using System.Linq.Expressions;

namespace EngineeringSoftwareLicensingTracker.Services
{
    public class ReservationProcess
    {

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
