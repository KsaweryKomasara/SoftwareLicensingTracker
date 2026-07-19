using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
namespace EngineeringSoftwareLicensingTracker.Services.ManagerService
{
    public class AnalyzerService
    {
        AppDbContext AppDbContext { get; set; }
        public AnalyzerService(AppDbContext dbContext)
        {
            this.AppDbContext = dbContext;
        }

        public async Task<decimal> GetFinancialReport()
        {
            decimal sum = await AppDbContext.Licenses.SumAsync(x => x.Price);
            return sum;
        }

        public async Task<List<LicenseEntity>> GetLicensesNotUsed()
        {
            DateTime border = DateTime.Now.AddDays(-30);
            return await AppDbContext.Licenses.Where(x => x.LastUsedDate < border).ToListAsync();
        }
    }
}
