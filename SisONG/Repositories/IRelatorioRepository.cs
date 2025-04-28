using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IRelatorioRepository
    {
        Task<IEnumerable<Relatorio>> GetAllAsync();
        Task<Relatorio> GetByIdAsync(int id);
        Task AddAsync(Relatorio relatorio);
        Task UpdateAsync(Relatorio relatorio);
        Task DeleteAsync(Relatorio relatorio);
    }
}
