using FinalProject.Data;
using FinalProject.Interfaces;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRespository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Employee employee)
        {
            _context.Add(employee);
            return Save();
        }

        public bool Delete(Employee employee)
        {
            _context.Remove(employee);
            return Save();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.employees.Include(i => i.role).FirstOrDefaultAsync(e => e.id == id);
        }

        public bool Save()
        {
            int success = _context.SaveChanges();
            if (success > 0)
                return true;
            return false;
        }

        public bool Update(Employee employee)
        {
            _context.Update(employee);
            return Save();
        }

        public IEnumerable<Role> GetPossibleRoles()
        {
            return _context.roles.ToList();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _context.roles.FirstOrDefaultAsync(r => r.id == id);
        }
    }
}
