using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Entities;
using EngineeringSoftwareLicensingTracker.Services.WorkerService;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringSoftwareLicensingTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenseController : Controller
    {

        private readonly AppDbContext appDbContext;
        private readonly LicenseService licenseService;

        public LicenseController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.licenseService = new LicenseService(this.appDbContext);
        }

        [HttpGet("getalllicenses")]
        public IActionResult getLicenses()
        {
            List<LicenseEntity> licenseList = this.appDbContext.Licenses.ToList();
            return Ok(licenseList);
        }

        [HttpGet("{licenseId}/getlicense")]
        public async Task<IActionResult> getLicense(int licenseId)
        {
            var license = await this.appDbContext.Licenses.FindAsync(licenseId);
            if (license == null)
            {
                return NotFound("Not found the license");
            }
            return Ok(license);

        }

        [HttpPut("license/{licenseid}/worker/{workerid}/reserve")]
        public async Task<IActionResult> Reserve(int licenseid, int workerid)
        {
            await this.licenseService.Reserve(licenseid, workerid);
            await this.appDbContext.SaveChangesAsync();
            return Ok("Reservation complete");
        }

        [HttpPut("license/{licenseid}/worker/{workerid}/release")]
        public async Task<IActionResult> Release(int licenseid, int workerid)
        {
            await this.licenseService.Release(licenseid, workerid);
            return Ok("Releasation complete");
        }

        [HttpPut("license/{licesnseid}/worker/{workerid}/extendlicensereservation")]
        public async Task<IActionResult> ExtendLicenseReservation(int licenseid, int workerid)
        {
            await this.licenseService.ExtendLicenseReservation(licenseid, workerid);
            return Ok("License extended");
        }

        [HttpPost("license/create")]
        public async Task<IActionResult> CreateLicense(LicenseEntity licenseEntity)
        {
            await this.licenseService.AddNewLicense(licenseEntity);
            return Ok("License reserved");
        }
    }
}
