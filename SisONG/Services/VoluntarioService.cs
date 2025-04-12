using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class VoluntarioService : IVoluntarioService
    {
        private readonly IVoluntarioRepository _repository;
        private readonly IMapper _mapper;

        public VoluntarioService(IVoluntarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VoluntarioReadDto>> GetAllAsync()
        {
            var voluntarios = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<VoluntarioReadDto>>(voluntarios);
        }

        public async Task<VoluntarioReadDto> GetByIdAsync(int id)
        {
            var voluntario = await _repository.GetByIdAsync(id);
            return voluntario == null ? null : _mapper.Map<VoluntarioReadDto>(voluntario);
        }

        public async Task<VoluntarioReadDto> CreateAsync(VoluntarioCreateDto dto)
        {
            var voluntario = _mapper.Map<Voluntario>(dto);
            voluntario.DataCadastro = DateTime.UtcNow;
            voluntario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
            await _repository.CreateAsync(voluntario);
            return _mapper.Map<VoluntarioReadDto>(voluntario);
        }

        public async Task<bool> UpdateAsync(int id, VoluntarioUpdateDto dto)
        {
            var voluntario = await _repository.GetByIdAsync(id);
            if (voluntario == null) return false;

            _mapper.Map(dto, voluntario);
            await _repository.UpdateAsync(voluntario);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var voluntario = await _repository.GetByIdAsync(id);
            if (voluntario == null) return false;

            await _repository.DeleteAsync(voluntario);
            return true;
        }
    }
}
