using EngineeringSoftwareLicensingTracker.DataBase;
using Microsoft.EntityFrameworkCore;
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
    }
}
