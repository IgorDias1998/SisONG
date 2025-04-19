using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Services
{
    public interface IAdministradorService
    {
        Task<IEnumerable<AdministradorReadDto>> GetAllAsync();
        Task<AdministradorReadDto> GetByIdAsync(int id);
        Task<AdministradorReadDto> CreateAsync(AdministradorCreateDto dto);
        Task<bool> UpdateAsync(int id, AdministradorUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
