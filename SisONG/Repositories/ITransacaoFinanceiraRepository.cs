using SisONG.Models;

namespace SisONG.Repositories
{
    public interface ITransacaoFinanceiraRepository
    {
        Task<IEnumerable<TransacaoFinanceira>> GetAllAsync();
        Task<TransacaoFinanceira> GetByIdAsync(int id);
        Task AddAsync(TransacaoFinanceira transacao);
        Task UpdateAsync(TransacaoFinanceira transacao);
        Task DeleteAsync(TransacaoFinanceira transacao);
        Task<decimal> CalcularSaldoAsync();
    }
}
