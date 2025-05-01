using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class PontoColetaService : IPontoColetaService
    {
        private readonly IPontoColetaRepository _repository;
        private readonly IMapper _mapper;

        public PontoColetaService(IPontoColetaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PontoColetaReadDto>> GetAllAsync()
        {
            var pontos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PontoColetaReadDto>>(pontos);
        }

        public async Task<PontoColetaReadDto> GetByIdAsync(int id)
        {
            var ponto = await _repository.GetByIdAsync(id);
            return ponto == null ? null : _mapper.Map<PontoColetaReadDto>(ponto);
        }

        public async Task<PontoColetaReadDto> CreateAsync(PontoColetaCreateDto dto)
        {
            var ponto = _mapper.Map<PontoColeta>(dto);
            await _repository.AddAsync(ponto);
            return _mapper.Map<PontoColetaReadDto>(ponto);
        }

        public async Task<bool> UpdateAsync(int id, PontoColetaUpdateDto dto)
        {
            var ponto = await _repository.GetByIdAsync(id);
            if (ponto == null) return false;

            _mapper.Map(dto, ponto);
            await _repository.UpdateAsync(ponto);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ponto = await _repository.GetByIdAsync(id);
            if (ponto == null) return false;

            await _repository.DeleteAsync(ponto);
            return true;
        }
    }
}
