using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public interface IDailyService
    {
        Task<int> CreateDaily(DailyData daily);
        Task<int> UpdateDaily(DailyData daily);
        Task<int> DeleteDaily(int? id);
        DailyData GetDailyById(int id);
        Task<IEnumerable<DailyData>> GetDailysByCompanyId(int id);
        Task<List<YearlyData>> GetDailysAsYearlys(int id);
    }

}
