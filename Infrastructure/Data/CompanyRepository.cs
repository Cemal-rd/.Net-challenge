using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly StoreContext _context;
        public CompanyRepository(StoreContext context)
        {
            _context = context;
        }
        //ireadonly yapmamızın sebebi burada company üzerinde sadece read işlemi yapmak istediğimiz için
        public async Task<IReadOnlyList<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
           return await _context.Companies.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
        public void Add(Company company)
        {
            _context.Add(company);
            // _context.Entry(company).State = EntityState.Added;
        }

        public void Delete(Company company)
        {
            _context.Remove(company);
            // _context.Entry(company).State = EntityState.Deleted;
        }

        public void Update(Company company)
        {
            _context.Attach(company);
            _context.Entry(company).State = EntityState.Modified;
        }
    }
}