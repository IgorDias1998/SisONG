using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class EventoVoluntarioService : IEventoVoluntarioService
    {
        private readonly IEventoVoluntarioRepository _repository;
        private readonly IMapper _mapper;

        public EventoVoluntarioService(IEventoVoluntarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(EventoVoluntarioCreateDto dto)
        {
            var entity = _mapper.Map<EventoVoluntario>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task<bool> RemoveAsync(int eventoId, int voluntarioId)
        {
            var eventoVoluntario = await _repository.GetByEventoAndVoluntarioIdAsync(eventoId, voluntarioId);
            if (eventoVoluntario == null)
                return false;

            await _repository.RemoveAsync(eventoId, voluntarioId);
            return true; 
        }

        public async Task<IEnumerable<EventoVoluntarioReadDto>> GetByEventoIdAsync(int eventoId)
        {
            var list = await _repository.GetByEventoIdAsync(eventoId);
            return _mapper.Map<IEnumerable<EventoVoluntarioReadDto>>(list);
        }

        public async Task<IEnumerable<EventoVoluntarioReadDto>> GetByVoluntarioIdAsync(int voluntarioId)
        {
            var list = await _repository.GetByVoluntarioIdAsync(voluntarioId);
            return _mapper.Map<IEnumerable<EventoVoluntarioReadDto>>(list);
        }
    }
}
