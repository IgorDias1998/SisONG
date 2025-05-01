using SisONG.DTOs;

namespace SisONG.Services
{
    public interface INotificacaoService
    {
        Task<IEnumerable<NotificacaoReadDto>> GetAllAsync();
        Task<NotificacaoReadDto> GetByIdAsync(int id);
        Task<NotificacaoReadDto> CreateAsync(NotificacaoCreateDto dto);
        Task<bool> UpdateAsync(int id, NotificacaoUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
