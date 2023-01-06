using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyByIdAsync(int id);
        Task<IReadOnlyList<Company>> GetCompaniesAsync();
        Task<bool> SaveChangesAsync();
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
    }
}