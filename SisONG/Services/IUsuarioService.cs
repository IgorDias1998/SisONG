using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioReadDto>> GetAllAsync();
        Task<UsuarioReadDto> GetByIdAsync(int id);
        Task<UsuarioReadDto> CreateAsync(UsuarioCreateDto dto);
        Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        //Task<UsuarioReadDto> AutenticarAsync(LoginDto loginDto);
        Task<UsuarioCompletoReadDto> AutenticarAsync(LoginDto loginDto);
    }
}
