using FinalProject.Models;

namespace FinalProject.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetByIdAsync(int id);
        bool Add(Role role);
        bool Update(Role role);
        bool Delete(Role role);
        bool Save();
    }
}
