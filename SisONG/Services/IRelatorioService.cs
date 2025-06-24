using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IRelatorioService
    {
        Task<IEnumerable<RelatorioReadDto>> GetAllAsync();
        Task<RelatorioReadDto> GetByIdAsync(int id);

        Task<RelatorioReadDto> AddAsync(RelatorioRequestDto requestDto);

        Task<RelatorioReadDto> UpdateAsync(int id, RelatorioUpdateDto updateDto);
        Task<bool> DeleteAsync(int id);
        Task<(List<RelatorioReadDto> Itens, int Total)> GetPaginadosAsync(int page, int pageSize);
    }
}
