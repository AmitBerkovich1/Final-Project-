using FinalProject.Models;

namespace FinalProject.Interfaces
{
    public interface ILineOfBusinessRepository
    {
        Task<IEnumerable<LineOfBusiness>> GetAll();
        Task<LineOfBusiness> GetByIdAsync(int id);
        bool Add(LineOfBusiness lineOfBusiness);
        bool Update(LineOfBusiness lineOfBusiness);
        bool Delete(LineOfBusiness lineOfBusiness);
        bool Save();
    }
}
