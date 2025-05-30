using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class TransacaoFinanceiraRepository : ITransacaoFinanceiraRepository
    {
        private readonly SisONGContext _context;

        public TransacaoFinanceiraRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransacaoFinanceira>> GetAllAsync()
        {
            return await _context.TransacoesFinanceiras.ToListAsync();
        }

        public async Task<TransacaoFinanceira> GetByIdAsync(int id)
        {
            return await _context.TransacoesFinanceiras.FindAsync(id);
        }

        public async Task AddAsync(TransacaoFinanceira transacao)
        {
            await _context.TransacoesFinanceiras.AddAsync(transacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransacaoFinanceira transacao)
        {
            _context.TransacoesFinanceiras.Update(transacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TransacaoFinanceira transacao)
        {
            _context.TransacoesFinanceiras.Remove(transacao);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> CalcularSaldoAsync()
        {
            // Somar todas as entradas (doações financeiras e lançamentos manuais que não são despesas)
            var entradas = await _context.TransacoesFinanceiras
                .Where(t => t.Destino != "Despesa")
                .SumAsync(t => t.Valor);

            // Somar todas as saídas (despesas)
            var saidas = await _context.TransacoesFinanceiras
                .Where(t => t.Destino == "Despesa")
                .SumAsync(t => t.Valor);

            var saldo = entradas - saidas;

            return saldo;
        }

        public async Task CreateAsync(TransacaoFinanceira transacao)
        {
            await _context.TransacoesFinanceiras.AddAsync(transacao);
        }
    }
}
