using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly SisONGContext _context;

        public RelatorioRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Relatorio>> GetAllAsync()
        {
            return await _context.Relatorios.ToListAsync();
        }

        public async Task<Relatorio> GetByIdAsync(int id)
        {
            return await _context.Relatorios.FindAsync(id);
        }

        public async Task AddAsync(Relatorio relatorio)
        {
            await _context.Relatorios.AddAsync(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Relatorio relatorio)
        {
            _context.Relatorios.Update(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Relatorio relatorio)
        {
            _context.Relatorios.Remove(relatorio);
            await _context.SaveChangesAsync();
        }
    }
}
