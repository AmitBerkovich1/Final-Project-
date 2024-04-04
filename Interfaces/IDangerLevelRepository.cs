using FinalProject.Models;

namespace FinalProject.Interfaces
{
    public interface IDangerLevelRepository
    {
        Task<IEnumerable<DangerLevel>> GetAll();
        Task<DangerLevel> GetByIdAsync(int id);
        bool Add(DangerLevel dangerLevel);
        bool Update(DangerLevel dangerLevel);
        bool Delete(DangerLevel dangerLevel);
        bool Save();
    }
}
