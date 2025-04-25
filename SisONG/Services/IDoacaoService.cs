using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IDoacaoService
    {
        Task<IEnumerable<DoacaoReadDto>> GetAllAsync();
        Task<DoacaoReadDto> GetByIdAsync(int id);
        Task<DoacaoReadDto> CreateAsync(DoacaoCreateDto dto);
        Task<bool> UpdateAsync(int id, DoacaoUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
