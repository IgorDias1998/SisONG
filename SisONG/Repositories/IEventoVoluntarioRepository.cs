using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IEventoVoluntarioRepository
    {
        Task AddAsync(EventoVoluntario eventoVoluntario);
        Task RemoveAsync(int eventoId, int voluntarioId);
        Task<IEnumerable<EventoVoluntario>> GetByEventoIdAsync(int eventoId);
        Task<IEnumerable<EventoVoluntario>> GetByVoluntarioIdAsync(int voluntarioId);
        Task<EventoVoluntario> GetByEventoAndVoluntarioIdAsync(int eventoId, int voluntarioId);
    }
}
