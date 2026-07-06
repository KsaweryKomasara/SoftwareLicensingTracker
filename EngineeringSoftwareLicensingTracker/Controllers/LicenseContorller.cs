using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Entities;
using EngineeringSoftwareLicensingTracker.Services.WorkerService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace EngineeringSoftwareLicensingTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenseController : Controller
    {

        private readonly AppDbContext appDbContext;
        private readonly LicenseService licenseService;

        public LicenseController(AppDbContext appDbContext  )
        {
            this.appDbContext = appDbContext;
            this.licenseService = new LicenseService(this.appDbContext);
        }

        [HttpGet]
        public IActionResult SomeString()
        {
            List<LicenseEntity> licenseList = this.appDbContext.Licenses.ToList();
            return Ok(licenseList);
        }

        [HttpPost("license/{licenseid}/worker/{workerid}/reserve")]
        public async Task<IActionResult> Reserve(int licenseid, int workerid)
        {
            await licenseService.Reserve(licenseid, workerid);
            return Ok("Reservation complete");
        }
    }
}
