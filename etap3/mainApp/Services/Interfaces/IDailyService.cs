using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public class IDailyService
    {
            Task<int> CreateDaily(DailyData daily);
            Task<int> UpdateDaily(DailyData daily);
            Task<int> DeleteDaily(int? id);
            DailyData GetDailyById(int id);
            Task<IEnumerable<DailyData>> GetDailys();
        }

}

