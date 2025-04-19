using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _repository;
        private readonly IMapper _mapper;

        public AdministradorService(IAdministradorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdministradorReadDto>> GetAllAsync()
        {
            var administradores = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AdministradorReadDto>>(administradores);
        }

        public async Task<AdministradorReadDto> GetByIdAsync(int id)
        {
            var administrador = await _repository.GetByIdAsync(id);
            return _mapper.Map<AdministradorReadDto>(administrador);
        }

        public async Task<AdministradorReadDto> CreateAsync(AdministradorCreateDto dto)
        {
            var administrador = _mapper.Map<Administrador>(dto);
            administrador.DataCadastro = DateTime.UtcNow;
            administrador.SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
            await _repository.CreateAsync(administrador);
            return _mapper.Map<AdministradorReadDto>(administrador);
        }

        public async Task<bool> UpdateAsync(int id, AdministradorUpdateDto dto)
        {
            var administrador = await _repository.GetByIdAsync(id);
            if (administrador == null) return false;

            _mapper.Map(dto, administrador);
            await _repository.UpdateAsync(administrador);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var administrador = await _repository.GetByIdAsync(id);
            if (administrador == null) return false;

            await _repository.DeleteAsync(administrador);
            return true;
        }
    }
}
