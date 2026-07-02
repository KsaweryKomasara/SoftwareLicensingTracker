using EngineeringSoftwareLicensingTracker.DataBase;
using EngineeringSoftwareLicensingTracker.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
namespace EngineeringSoftwareLicensingTracker.Services.ManagerService
{
    public class Analyzer
    {
        AppDbContext AppDbContext { get; set; }
        public Analyzer(AppDbContext dbContext)
        {
            this.AppDbContext = dbContext;
        }

        public async Task<decimal> GetFinancialReport()
        {
            return await AppDbContext.Licenses.SumAsync(x => x.Price);
        }

        public async Task<List<Entities.License>> GetLicensesNotUsed()
        {
            DateTime border = DateTime.Now.AddDays(-30);
            return await AppDbContext.Licenses.Where(x => x.LastUsedDate < border).ToListAsync();
        }
    }
}
