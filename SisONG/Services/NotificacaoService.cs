using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class NotificacaoService  : INotificacaoService
    {
        private readonly INotificacaoRepository _repository;
        private readonly IMapper _mapper;

        public NotificacaoService(INotificacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificacaoReadDto>> GetAllAsync()
        {
            var notificacoes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<NotificacaoReadDto>>(notificacoes);
        }

        public async Task<NotificacaoReadDto> GetByIdAsync(int id)
        {
            var notificacao = await _repository.GetByIdAsync(id);
            return notificacao == null ? null : _mapper.Map<NotificacaoReadDto>(notificacao);
        }

        public async Task<NotificacaoReadDto> CreateAsync(NotificacaoCreateDto dto)
        {
            var notificacao = _mapper.Map<Notificacao>(dto);
            notificacao.DataEnvio = DateTime.UtcNow;
            await _repository.AddAsync(notificacao);
            return _mapper.Map<NotificacaoReadDto>(notificacao);
        }

        public async Task<bool> UpdateAsync(int id, NotificacaoUpdateDto dto)
        {
            var notificacao = await _repository.GetByIdAsync(id);
            if (notificacao == null) return false;

            _mapper.Map(dto, notificacao);
            await _repository.UpdateAsync(notificacao);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var notificacao = await _repository.GetByIdAsync(id);
            if (notificacao == null) return false;

            await _repository.DeleteAsync(notificacao);
            return true;
        }
    }
}
