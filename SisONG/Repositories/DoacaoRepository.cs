using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly SisONGContext _context;

        public DoacaoRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doacao>> GetAllAsync()
        {
            return await _context.Doacoes.Include(d => d.Doador).ToListAsync();
        }

        public async Task<Doacao> GetByIdAsync(int id)
        {
            return await _context.Doacoes.Include(d => d.Doador).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task CreateAsync(Doacao doacao)
        {
            await _context.Doacoes.AddAsync(doacao);
        }

        public async Task UpdateAsync(Doacao doacao)
        {
            _context.Doacoes.Update(doacao);
        }

        public async Task DeleteAsync(Doacao doacao)
        {
            _context.Doacoes.Remove(doacao);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
