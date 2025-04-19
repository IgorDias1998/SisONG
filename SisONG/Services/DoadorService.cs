using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class DoadorService : IDoadorService
    {
        private readonly IDoadorRepository _repository;
        private readonly IMapper _mapper;

        public DoadorService(IDoadorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoadorReadDto>> GetAllAsync()
        {
            var doadores = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoadorReadDto>>(doadores);
        }

        public async Task<DoadorReadDto> GetByIdAsync(int id)
        {
            var doador = await _repository.GetByIdAsync(id);
            return _mapper.Map<DoadorReadDto>(doador);
        }

        public async Task<DoadorReadDto> CreateAsync(DoadorCreateDto dto)
        {
            var doador = _mapper.Map<Doador>(dto);
            doador.DataCadastro = DateTime.UtcNow;
            doador.SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
            await _repository.CreateAsync(doador);
            return _mapper.Map<DoadorReadDto>(doador);
        }

        public async Task<bool> UpdateAsync(int id, DoadorUpdateDto dto)
        {
            var doador = await _repository.GetByIdAsync(id);
            if (doador == null) return false;

            _mapper.Map(dto, doador);
            await _repository.UpdateAsync(doador);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doador = await _repository.GetByIdAsync(id);
            if (doador == null) return false;

            await _repository.DeleteAsync(doador);
            return true;
        }
    }
}
