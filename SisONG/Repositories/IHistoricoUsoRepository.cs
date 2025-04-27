using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IHistoricoUsoRepository
    {
        Task<IEnumerable<HistoricoUso>> GetAllAsync();
        Task<HistoricoUso> GetByIdAsync(int id);
        Task AddAsync(HistoricoUso historicoUso);
        Task UpdateAsync(HistoricoUso historicoUso);
        Task DeleteAsync(HistoricoUso historicoUso);
    }
}
