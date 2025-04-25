using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class ProdutoInsumoRepository : IProdutoInsumoRepository
    {
        private readonly SisONGContext _context;

        public ProdutoInsumoRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoInsumo>> GetAllAsync()
        {
            return await _context.ProdutosInsumos.ToListAsync();
        }

        public async Task<ProdutoInsumo> GetByIdAsync(int id)
        {
            return await _context.ProdutosInsumos.FindAsync(id);
        }

        public async Task CreateAsync(ProdutoInsumo produto)
        {
            await _context.ProdutosInsumos.AddAsync(produto);
        }

        public async Task UpdateAsync(ProdutoInsumo produto)
        {
            _context.ProdutosInsumos.Update(produto);
        }

        public async Task DeleteAsync(ProdutoInsumo produto)
        {
            _context.ProdutosInsumos.Remove(produto);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
