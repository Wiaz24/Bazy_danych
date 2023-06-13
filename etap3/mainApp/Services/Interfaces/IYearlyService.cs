using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public interface IYearlyService
    {
        Task<int> CreateYearly(YearlyData yearly);
        Task<int> UpdateYearly(YearlyData yearly);
        Task<int> DeleteYearly(int? id);
        YearlyData GetYearlyById(int id);
        Task<IEnumerable<YearlyData>> GetYearlys();
    }
}
