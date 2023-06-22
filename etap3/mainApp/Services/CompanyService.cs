using Microsoft.EntityFrameworkCore;
using Bazy_danych.Models;
using Bazy_danych.Services.Interfaces;

namespace Bazy_danych.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _dbContext;
        public CompanyService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateCompany(Company company)
        {
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();
            return company.ID_firmy;
        }
        public async Task<int> UpdateCompany(Company company)
        {
            _dbContext.Companies.Update(company);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteCompany(int? id)
        {
            if (id == null)
                return 0;

            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null)
                return 0;

            _dbContext.Companies.Remove(company);
            return await _dbContext.SaveChangesAsync();
        }
        public Company GetCompanyById(int id)
        {
            return _dbContext.Companies.Find(id);
        }
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _dbContext.Companies.ToListAsync();
        }
    }
}
