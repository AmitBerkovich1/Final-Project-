using FinalProject.Models;

namespace FinalProject.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAll();
        Task<Company> GetByIdAsync(int id);
        bool Add(Company company);
        bool Update(Company company);
        bool Delete(Company company);
        bool Save();
    }
}
