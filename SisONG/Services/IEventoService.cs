using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IEventoService
    {
        Task<IEnumerable<EventoReadDto>> GetAllAsync();
        Task<EventoReadDto> GetByIdAsync(int id);
        Task<EventoReadDto> CreateAsync(EventoCreateDto dto);
        Task<bool> UpdateAsync(int id, EventoUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<EventoComContagemDto>> GetEventosComContagemAsync();
    }
}
