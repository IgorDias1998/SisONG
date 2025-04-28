using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IRelatorioService
    {
        Task<IEnumerable<RelatorioReadDto>> GetAllAsync();
        Task<RelatorioReadDto> GetByIdAsync(int id);
        Task<RelatorioReadDto> AddAsync(RelatorioCreateDto createDto);
        Task<RelatorioReadDto> UpdateAsync(int id, RelatorioUpdateDto updateDto);
        Task<bool> DeleteAsync(int id);
    }
}
