using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class CaseRepository : ICaseRepository
    {
        private readonly ApplicationDbContext _context;

        public CaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Case myCase)
        {
            _context.Add(myCase);
            return Save();
        }

        public bool Delete(Case myCase)
        {
            _context.Remove(myCase);
            return Save();
        }

        public async Task<IEnumerable<Case>> GetAll()
        {
            return await _context.cases.ToListAsync();
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            return await _context.cases.Include(i => i.company).Include(c => c.level).FirstOrDefaultAsync(r => r.id == id);
        }

        public bool Save()
        {
            int success = _context.SaveChanges();
            if (success > 0)
                return true;
            return false;
        }

        public bool Update(Case myCase)
        {
            _context.Update(myCase);
            return Save();
        }
    }
}
