using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IDoadorService
    {
        Task<IEnumerable<DoadorReadDto>> GetAllAsync();
        Task<DoadorReadDto> GetByIdAsync(int id);
        Task<DoadorReadDto> CreateAsync(DoadorCreateDto dto);
        Task<bool> UpdateAsync(int id, DoadorUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
