using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
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
