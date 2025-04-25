using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IProdutoInsumoService
    {
        Task<IEnumerable<ProdutoInsumoReadDto>> GetAllAsync();
        Task<ProdutoInsumoReadDto> GetByIdAsync(int id);
        Task<ProdutoInsumoReadDto> CreateAsync(ProdutoInsumoCreateDto dto);
        Task<bool> UpdateAsync(int id, ProdutoInsumoUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
