using Microsoft.EntityFrameworkCore;
using Platformy_Programowania_1.Models;
using Platformy_Programowania_1.Services.Interfaces;

namespace Platformy_Programowania_1.Services
{
    public class DailyService : IDailyService
    {
        private readonly AppDbContext _dbContext;
        public DailyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateDaily(DailyData daily)
        {
            _dbContext.Daily.Add(daily);
            await _dbContext.SaveChangesAsync();
            return daily.ID_rekordu;
        }
        public async Task<int> UpdateDaily(DailyData daily)
        {
            _dbContext.Daily.Update(daily);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteDaily(int? id)
        {
            if (id == null)
                return 0;

            var daily = await _dbContext.Daily.FindAsync(id);
            if (daily == null)
                return 0;

            _dbContext.Daily.Remove(daily);
            return await _dbContext.SaveChangesAsync();
        }
        public DailyData GetDailyById(int id)
        {
            return _dbContext.Daily.Find(id);
        }
        public async Task<IEnumerable<DailyData>> GetDailysByCompanyId(int id)
        {
            return await _dbContext.Daily
                .Where(h => h.ID_firmy == id)
                .ToListAsync();
        }
        public async Task<List<YearlyData>> GetDailysAsYearlys(int id)
        {
            List<YearlyData> yearlyData = new List<YearlyData>();
            var dailys = await GetDailysByCompanyId(id);
            foreach (var item in dailys)
            {
                YearlyData yearly = new YearlyData();
                yearly.ID_firmy = item.ID_firmy;
                yearly.ID_rekordu = item.ID_rekordu;
                yearly.Cena = item.Cena;
                yearly.Dzien = DateTime.Today;
                yearly.Dzien = yearly.Dzien.Add(item.Godzina);
                yearlyData.Add(yearly);
            }
            return yearlyData;
        }
    }
}
