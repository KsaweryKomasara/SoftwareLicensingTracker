using EngineeringSoftwareLicensingTracker.DataBase;
namespace EngineeringSoftwareLicensingTracker.Services.WorkerService
{

    // Licencje stanowiskowe
    public class NodeLockLicenseServices : LicenseService
    {

        public NodeLockLicenseServices(AppDbContext appDbContext) : base(appDbContext) { }

        public Boolean VerifyWorkplace(String assignedMAC, String workplaceMAC)
        {

            // W tej funckiji musimy mieć adres mac z bazy i adres mac komputera z którego ta licencja jest używana
            // Przykładowy adres MAC 00:1A:2B:3C:4D:5E

            assignedMAC = ConvertMACAddress(assignedMAC);
            workplaceMAC = ConvertMACAddress(workplaceMAC);

            if (!isCorrect(assignedMAC))
            {
                throw new ArgumentException("Assigned MAC address is not correct. It is not a MAC address.");
            }

            if (!isCorrect(workplaceMAC))
            {
                throw new ArgumentException("Local MAC address is not correct. It is not a MAC address.");
            }

            if (assignedMAC.Equals(workplaceMAC))
            {
                return true;
            } else return false;

        }

        private String ConvertMACAddress(String MACAddress)
        {
            return MACAddress.ToLower().Replace(":", "").Replace("-","");
        }

        private Boolean isCorrect(String MACAddress)
        {
            if (MACAddress == null || MACAddress.Length != 12)
            {
                return false;
            } return true;
        }
    }
}
