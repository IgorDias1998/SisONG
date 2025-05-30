using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class DoacaoService : IDoacaoService
    {
        private readonly IDoacaoRepository _repository;
        private readonly ITransacaoFinanceiraRepository _transacaoRepository;
        private readonly IMapper _mapper;

        public DoacaoService(IDoacaoRepository repository, ITransacaoFinanceiraRepository transacaoRepository, IMapper mapper)
        {
            _repository = repository;
            _transacaoRepository = transacaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoacaoReadDto>> GetAllAsync()
        {
            var doacoes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoacaoReadDto>>(doacoes);
        }

        public async Task<DoacaoReadDto> GetByIdAsync(int id)
        {
            var doacao = await _repository.GetByIdAsync(id);
            return doacao == null ? null : _mapper.Map<DoacaoReadDto>(doacao);
        }

        public async Task<DoacaoReadDto> CreateAsync(DoacaoCreateDto dto)
        {
            var doacao = _mapper.Map<Doacao>(dto);
            await _repository.CreateAsync(doacao);
            if (dto.Tipo == "Financeira" && dto.Valor.HasValue)
            {
                var transacao = new TransacaoFinanceira
                {
                    Data = DateTime.UtcNow,
                    Origem = "Doação",
                    Destino = $"Doação financeira de Doador {dto.DoadorId}",
                    Valor = dto.Valor.Value,
                    MetodoPagamento = "Pix"
                };

                await _transacaoRepository.CreateAsync(transacao);
            }
            await _repository.SaveChangesAsync();
            return _mapper.Map<DoacaoReadDto>(doacao);
        }

        public async Task<bool> UpdateAsync(int id, DoacaoUpdateDto dto)
        {
            var doacao = await _repository.GetByIdAsync(id);
            if (doacao == null) return false;

            _mapper.Map(dto, doacao);
            await _repository.UpdateAsync(doacao);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doacao = await _repository.GetByIdAsync(id);
            if (doacao == null) return false;

            await _repository.DeleteAsync(doacao);
            return await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoacaoReadDto>> GetByDoadorIdAsync(int doadorId)
        {
            var doacoes = await _repository.GetByDoadorIdAsync(doadorId);
            return _mapper.Map<IEnumerable<DoacaoReadDto>>(doacoes);
        }
    }
}
