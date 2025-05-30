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
            // Entradas via doações financeiras
            var doacoesFinanceiras = await _context.Doacoes
                .Where(d => d.Tipo == "Financeira")
                .SumAsync(d => d.Valor);

            // Entradas via transações (não despesas)
            var outrasEntradas = await _context.TransacoesFinanceiras
                .Where(t => t.Destino != "Despesa")
                .SumAsync(t => t.Valor);

            // Saídas via transações (despesas)
            var despesas = await _context.TransacoesFinanceiras
                .Where(t => t.Destino == "Despesa")
                .SumAsync(t => t.Valor);

            var saldo = (doacoesFinanceiras + outrasEntradas) - despesas;

            return (decimal)saldo;
        }
    }
}
