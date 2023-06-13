using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public interface IYearlyService
    {
        Task<int> CreateYearly(YearlyData yearly);
        Task<int> UpdateYearly(YearlyData yearly);
        Task<int> DeleteYearly(int? id);
        YearlyData GetYearlyById(int id);
<<<<<<< HEAD
        Task<IEnumerable<YearlyData>> GetYearlysByCompanyId(int id);
    }
}
=======
        Task<IEnumerable<YearlyData>> GetYearlys();
    }
}
>>>>>>> 3411c1a81527d42f7aa13990e192e9835687e598
