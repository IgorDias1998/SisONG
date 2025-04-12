using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IVoluntarioRepository
    {
        Task<IEnumerable<Voluntario>> GetAllAsync();
        Task<Voluntario> GetByIdAsync(int id);
        Task CreateAsync(Voluntario voluntario);
        Task UpdateAsync(Voluntario voluntario);
        Task DeleteAsync(Voluntario voluntario);
        Task<bool> ExistsAsync(int id);
    }
}
