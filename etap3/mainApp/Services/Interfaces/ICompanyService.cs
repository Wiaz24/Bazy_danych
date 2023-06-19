using Bazy_danych.Models;

namespace Bazy_danych.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<int> CreateCompany(Company company);
        Task<int> UpdateCompany(Company company);
        Task<int> DeleteCompany(int? id);
        Company GetCompanyById(int id);
        Task<IEnumerable<Company>> GetCompanies();
    }
}
