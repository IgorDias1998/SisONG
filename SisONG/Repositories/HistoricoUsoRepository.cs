using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class HistoricoUsoRepository : IHistoricoUsoRepository
    {
        private readonly SisONGContext _context;

        public HistoricoUsoRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HistoricoUso historicoUso)
        {
            await _context.HistoricosDeUso.AddAsync(historicoUso);
            await _context.SaveChangesAsync();
        }

        public async Task<HistoricoUso> GetByIdAsync(int id)
        {
            return await _context.HistoricosDeUso
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<HistoricoUso>> GetAllAsync()
        {
            return await _context.HistoricosDeUso
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(HistoricoUso historicoUso)
        {
            _context.HistoricosDeUso.Update(historicoUso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(HistoricoUso historicoUso)
        {
            _context.HistoricosDeUso.Remove(historicoUso);
            await _context.SaveChangesAsync();
        }
    }
}
