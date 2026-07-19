using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Services.ManagerService;
using EngineeringSoftwareLicensingTracker.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace EngineeringSoftwareLicensingTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyzerController : Controller
    {
        private readonly AppDbContext AppDbContext;
        private readonly AnalyzerService AnalyzerService;

        public AnalyzerController(AppDbContext appDbContext)
        {
            this.AppDbContext = appDbContext;
            this.AnalyzerService = new AnalyzerService(appDbContext);
        }

        [HttpGet("analyzer/getfinancialreport")]
        public async Task<IActionResult> GetFinancialResult()
        {
            decimal sum = await this.AnalyzerService.GetFinancialReport();
            return Ok("This is the financial report: " + sum);
        }

        [HttpGet("analyzer/getlicensesnotused")]
        public async Task<IActionResult> GetLicensesNotUsed()
        {
            List<LicenseEntity> licensesNotUsed = await this.AnalyzerService.GetLicensesNotUsed();
            return Ok(licensesNotUsed);
        }

    }
}
