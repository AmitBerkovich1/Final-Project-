using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class LineOfBuisnessRepository : ILineOfBusinessRepository
    {
        private readonly ApplicationDbContext _context;

        public LineOfBuisnessRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(LineOfBusiness lineOfBusiness)
        {
            _context.Add(lineOfBusiness);
            return Save();
        }

        public bool Delete(LineOfBusiness lineOfBusiness)
        {
            _context.Remove(lineOfBusiness);
            return Save();
        }

        public async Task<IEnumerable<LineOfBusiness>> GetAll()
        {
            return await _context.lineOfBusiness.ToListAsync();
        }

        public async Task<LineOfBusiness> GetByIdAsync(int id)
        {
            return await _context.lineOfBusiness.FirstOrDefaultAsync(l => l.id == id);
        }

        public bool Save()
        {
            int success = _context.SaveChanges();
            if (success > 0)
                return true;
            return false;
        }

        public bool Update(LineOfBusiness lineOfBusiness)
        {
            _context.Update(lineOfBusiness);
            return Save();
        }
    }
}
