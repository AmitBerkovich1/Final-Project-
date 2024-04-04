using FinalProject.Models;

namespace FinalProject.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetByIdAsync(int id);
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
        bool Save();
        public IEnumerable<Role> GetPossibleRoles();
        public Task<Role> GetRoleByIdAsync(int id);
    }
}
