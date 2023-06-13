using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public interface IDailyService
    {
<<<<<<< HEAD
        Task<int> CreateDaily(DailyData daily);
        Task<int> UpdateDaily(DailyData daily);
        Task<int> DeleteDaily(int? id);
        DailyData GetDailyById(int id);
        Task<IEnumerable<DailyData>> GetDailysByCompanyId(int id);
    }

}
=======
            Task<int> CreateDaily(DailyData daily);
            Task<int> UpdateDaily(DailyData daily);
            Task<int> DeleteDaily(int? id);
            DailyData GetDailyById(int id);
            Task<IEnumerable<DailyData>> GetDailys();
        }

}

>>>>>>> 3411c1a81527d42f7aa13990e192e9835687e598
