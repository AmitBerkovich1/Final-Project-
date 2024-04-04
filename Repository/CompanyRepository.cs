using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Company company)
        {
            _context.Add(company);
            return Save();
        }

        public bool Delete(Company company)
        {
            _context.Remove(company);
            return Save();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.company.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.company.Include(i => i.lineOfBusiness).FirstOrDefaultAsync(c => c.id == id);
        }

        public bool Save()
        {
            int success = _context.SaveChanges();
            if (success > 0)
                return true;
            return false;
        }

        public bool Update(Company company)
        {
            _context.Update(company);
            return Save();
        }
    }
}
