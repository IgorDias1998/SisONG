using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IDoadorRepository
    {
        Task<IEnumerable<Doador>> GetAllAsync();
        Task<Doador> GetByIdAsync(int id);
        Task CreateAsync(Doador doador);
        Task UpdateAsync(Doador doador);
        Task DeleteAsync(Doador doador);

    }
}
