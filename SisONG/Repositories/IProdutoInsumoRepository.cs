using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IProdutoInsumoRepository
    {
        Task<IEnumerable<ProdutoInsumo>> GetAllAsync();
        Task<ProdutoInsumo> GetByIdAsync(int id);
        Task CreateAsync(ProdutoInsumo produto);
        Task UpdateAsync(ProdutoInsumo produto);
        Task DeleteAsync(ProdutoInsumo produto);
        Task SaveChangesAsync();
    }
}
