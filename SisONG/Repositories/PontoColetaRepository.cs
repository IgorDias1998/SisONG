using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class PontoColetaRepository : IPontoColetaRepository
    {
        private readonly SisONGContext _context;

        public PontoColetaRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PontoColeta>> GetAllAsync()
        {
            return await _context.PontosDeColeta.ToListAsync();
        }

        public async Task<PontoColeta> GetByIdAsync(int id)
        {
            return await _context.PontosDeColeta.FindAsync(id);
        }

        public async Task AddAsync(PontoColeta ponto)
        {
            await _context.PontosDeColeta.AddAsync(ponto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PontoColeta ponto)
        {
            _context.PontosDeColeta.Update(ponto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PontoColeta ponto)
        {
            _context.PontosDeColeta.Remove(ponto);
            await _context.SaveChangesAsync();
        }
    }
}
