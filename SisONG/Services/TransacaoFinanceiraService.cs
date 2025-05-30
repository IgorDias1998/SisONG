using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class TransacaoFinanceiraService : ITransacaoFinanceiraService
    {
        private readonly ITransacaoFinanceiraRepository _repository;
        private readonly IMapper _mapper;

        public TransacaoFinanceiraService(ITransacaoFinanceiraRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransacaoFinanceiraReadDto>> GetAllAsync()
        {
            var transacoes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TransacaoFinanceiraReadDto>>(transacoes);
        }

        public async Task<TransacaoFinanceiraReadDto> GetByIdAsync(int id)
        {
            var transacao = await _repository.GetByIdAsync(id);
            return _mapper.Map<TransacaoFinanceiraReadDto>(transacao);
        }

        public async Task<TransacaoFinanceiraReadDto> AddAsync(TransacaoFinanceiraCreateDto createDto)
        {
            var transacao = _mapper.Map<TransacaoFinanceira>(createDto);
            await _repository.AddAsync(transacao);
            return _mapper.Map<TransacaoFinanceiraReadDto>(transacao);
        }

        public async Task<TransacaoFinanceiraReadDto> UpdateAsync(int id, TransacaoFinanceiraUpdateDto updateDto)
        {
            var transacao = await _repository.GetByIdAsync(id);

            if (transacao == null)
                return null;

            _mapper.Map(updateDto, transacao);
            await _repository.UpdateAsync(transacao);
            return _mapper.Map<TransacaoFinanceiraReadDto>(transacao);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transacao = await _repository.GetByIdAsync(id);
            if (transacao == null)
                return false;

            await _repository.DeleteAsync(transacao);
            return true;
        }

        public async Task<decimal> CalcularSaldoAsync()
        {
            var saldo = await _repository.CalcularSaldoAsync();
            return saldo;
        }
    }
}
