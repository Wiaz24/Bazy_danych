using Bazy_danych.Models;

namespace Bazy_danych.Services.Interfaces
{
    public interface IDailyService
    {
        Task<int> CreateDaily(DailyData daily);
        Task<int> UpdateDaily(DailyData daily);
        Task<int> DeleteDaily(int? id);
        DailyData GetDailyById(int id);
        Task<IEnumerable<DailyData>> GetDailysByCompanyId(int id);
        Task<List<YearlyData>> GetDailysAsYearlys(int id);
        Task<int> New_Daily(int company_id);
    }

}
