using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IPontoColetaRepository
    {
        Task<IEnumerable<PontoColeta>> GetAllAsync();
        Task<PontoColeta> GetByIdAsync(int id);
        Task AddAsync(PontoColeta ponto);
        Task UpdateAsync(PontoColeta ponto);
        Task DeleteAsync(PontoColeta ponto);
    }
}
