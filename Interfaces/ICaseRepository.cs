using FinalProject.Models;

namespace FinalProject.Interfaces
{
    public interface ICaseRepository
    {
        Task<IEnumerable<Case>> GetAll();
        Task<Case> GetByIdAsync(int id);
        bool Add(Case myCase);
        bool Update(Case myCase);
        bool Delete(Case myCase);
        bool Save();
    }
}
