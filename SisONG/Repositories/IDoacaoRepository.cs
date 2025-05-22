using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IDoacaoRepository
    {
        Task<IEnumerable<Doacao>> GetAllAsync();
        Task<Doacao> GetByIdAsync(int id);
        Task CreateAsync(Doacao doacao);
        Task UpdateAsync(Doacao doacao);
        Task DeleteAsync(Doacao doacao);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Doacao>> GetByDoadorIdAsync(int id);
    }
}
