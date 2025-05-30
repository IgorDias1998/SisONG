using SisONG.DTOs;

namespace SisONG.Services
{
    public interface ITransacaoFinanceiraService
    {
        Task<IEnumerable<TransacaoFinanceiraReadDto>> GetAllAsync();
        Task<TransacaoFinanceiraReadDto> GetByIdAsync(int id);
        Task<TransacaoFinanceiraReadDto> AddAsync(TransacaoFinanceiraCreateDto createDto);
        Task<TransacaoFinanceiraReadDto> UpdateAsync(int id, TransacaoFinanceiraUpdateDto updateDto);
        Task<bool> DeleteAsync(int id);
        Task<decimal> CalcularSaldoAsync();
    }
}
