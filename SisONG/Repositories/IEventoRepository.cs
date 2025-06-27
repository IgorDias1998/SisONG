using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> GetAllAsync();
        Task<Evento> GetByIdAsync(int id);
        Task CreateAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(Evento evento);
        Task<List<EventoComContagemDto>> GetEventosComContagemAsync();
    }
}
