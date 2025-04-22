using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _repository;
        private readonly IMapper _mapper;

        public EventoService(IEventoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventoReadDto>> GetAllAsync()
        {
            var eventos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EventoReadDto>>(eventos);
        }

        public async Task<EventoReadDto> GetByIdAsync(int id)
        {
            var evento = await _repository.GetByIdAsync(id);
            return evento == null ? null : _mapper.Map<EventoReadDto>(evento);
        }

        public async Task<EventoReadDto> CreateAsync(EventoCreateDto dto)
        {
            var evento = _mapper.Map<Evento>(dto);
            await _repository.CreateAsync(evento);
            return _mapper.Map<EventoReadDto>(evento);
        }

        public async Task<bool> UpdateAsync(int id, EventoUpdateDto dto)
        {
            var evento = await _repository.GetByIdAsync(id);
            if (evento == null) return false;

            _mapper.Map(dto, evento);
            await _repository.UpdateAsync(evento);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var evento = await _repository.GetByIdAsync(id);
            if (evento == null) return false;

            await _repository.DeleteAsync(evento);
            return true;
        }
    }
}
