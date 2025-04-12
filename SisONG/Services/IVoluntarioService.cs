using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IVoluntarioService
    {
        Task<IEnumerable<VoluntarioReadDto>> GetAllAsync();
        Task<VoluntarioReadDto> GetByIdAsync(int id);
        Task<VoluntarioReadDto> CreateAsync(VoluntarioCreateDto dto);
        Task<bool> UpdateAsync(int id, VoluntarioUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
