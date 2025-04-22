using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IEventoVoluntarioService
    {
        Task AddAsync(EventoVoluntarioCreateDto dto);
        Task<bool> RemoveAsync(int eventoId, int voluntarioId);
        Task<IEnumerable<EventoVoluntarioReadDto>> GetByEventoIdAsync(int eventoId);
        Task<IEnumerable<EventoVoluntarioReadDto>> GetByVoluntarioIdAsync(int voluntarioId);
    }
}
