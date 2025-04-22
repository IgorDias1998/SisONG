using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;
using System;

namespace SisONG.Repositories
{
    public class EventoVoluntarioRepository : IEventoVoluntarioRepository
    {
        private readonly SisONGContext _context;

        public EventoVoluntarioRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EventoVoluntario eventoVoluntario)
        {
            _context.EventoVoluntarios.Add(eventoVoluntario);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int eventoId, int voluntarioId)
        {
            var ev = await _context.EventoVoluntarios
                .FirstOrDefaultAsync(e => e.EventoId == eventoId && e.VoluntarioId == voluntarioId);

            if (ev != null)
            {
                _context.EventoVoluntarios.Remove(ev);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventoVoluntario>> GetByEventoIdAsync(int eventoId)
        {
            return await _context.EventoVoluntarios
                .Include(ev => ev.Voluntario)
                .Where(ev => ev.EventoId == eventoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<EventoVoluntario>> GetByVoluntarioIdAsync(int voluntarioId)
        {
            return await _context.EventoVoluntarios
                .Include(ev => ev.Evento)
                .Where(ev => ev.VoluntarioId == voluntarioId)
                .ToListAsync();
        }

        public async Task<EventoVoluntario> GetByEventoAndVoluntarioIdAsync(int eventoId, int voluntarioId)
        {
            return await _context.EventoVoluntarios
                .FirstOrDefaultAsync(ev => ev.EventoId == eventoId && ev.VoluntarioId == voluntarioId);
        }
    }
}
