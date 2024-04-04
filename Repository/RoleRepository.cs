using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Role role)
        {
            _context.Add(role);
            return Save();
        }

        public bool Delete(Role role)
        {
            _context.Remove(role);
            return Save();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.roles.FirstOrDefaultAsync(r => r.id == id);
        }

        public bool Save()
        {
           int success = _context.SaveChanges();
            if (success > 0) 
                return true;
            return false;
        }

        public bool Update(Role role)
        {
            _context.Update(role);
            return Save();
        }
    }
}
