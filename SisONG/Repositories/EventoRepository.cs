using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly SisONGContext _context;

        public EventoRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            return await _context.Eventos
                .Include(e => e.EventoVoluntarios)
                .ToListAsync();
        }

        public async Task<Evento> GetByIdAsync(int id)
        {
            return await _context.Eventos
                .Include(e => e.EventoVoluntarios)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Evento evento)
        {
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
        }
    }
}
