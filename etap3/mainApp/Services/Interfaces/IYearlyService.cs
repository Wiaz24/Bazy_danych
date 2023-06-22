using Bazy_danych.Models;

namespace Bazy_danych.Services.Interfaces
{
    public interface IYearlyService
    {
        Task<int> CreateYearly(YearlyData yearly);
        Task<int> UpdateYearly(YearlyData yearly);
        Task<int> DeleteYearly(int? id);
        YearlyData GetYearlyById(int id);
        Task<IEnumerable<YearlyData>> GetYearlysByCompanyId(int id);
        Task<int> New_Yearly(int company_id);

    }
}