using Microsoft.EntityFrameworkCore;
using Bazy_danych.Models;
using Bazy_danych.Services.Interfaces;

namespace Bazy_danych.Services
{
    public class YearlyService : IYearlyService
    {
        private readonly AppDbContext _dbContext;
        public YearlyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateYearly(YearlyData yearly)
        {
            _dbContext.Yearly.Add(yearly);
            await _dbContext.SaveChangesAsync();
            return yearly.ID_rekordu;
        }
        public async Task<int> UpdateYearly(YearlyData yearly)
        {
            _dbContext.Yearly.Update(yearly);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteYearly(int? id)
        {
            if (id == null)
                return 0;

            var yearly = await _dbContext.Yearly.FindAsync(id);
            if (yearly == null)
                return 0;

            _dbContext.Yearly.Remove(yearly);
            return await _dbContext.SaveChangesAsync();
        }
        public YearlyData GetYearlyById(int id)
        {
            return _dbContext.Yearly.Find(id);
        }
        public async Task<IEnumerable<YearlyData>> GetYearlysByCompanyId(int id)
        {
            return await _dbContext.Yearly
                //.Where(h => h.ID_firmy == id)
                .ToListAsync();
        }
    }
}
