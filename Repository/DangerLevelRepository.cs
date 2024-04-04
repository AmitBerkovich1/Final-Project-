using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class DangerLevelRepository : IDangerLevelRepository
    {
        private readonly ApplicationDbContext _context;

        public DangerLevelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(DangerLevel dangerLevel)
        {
            _context.Add(dangerLevel);
            return Save();
        }

        public bool Delete(DangerLevel dangerLevel)
        {
           _context.Remove(dangerLevel);
            return Save();
        }

        public async Task<IEnumerable<DangerLevel>> GetAll()
        {
            return await _context.dangerLevels.ToListAsync();
        }

        public async Task<DangerLevel> GetByIdAsync(int id)
        {
            return await _context.dangerLevels.FirstOrDefaultAsync(d => d.id == id);
        }

        public bool Save()
        {
            int success = _context.SaveChanges();
            if (success > 0)
                return true;
            return false;
        }

        public bool Update(DangerLevel dangerLevel)
        {
            _context.Update(dangerLevel);
            return Save();
        }
    }
}
