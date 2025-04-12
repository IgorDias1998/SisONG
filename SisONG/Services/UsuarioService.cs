using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioReadDto>> GetAllAsync()
        {
            var usuarios = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioReadDto>>(usuarios);
        }

        public async Task<UsuarioReadDto> GetByIdAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            return _mapper.Map<UsuarioReadDto>(usuario);
        }

        public async Task<UsuarioReadDto> CreateAsync(UsuarioCreateDto dto)
        {
            Usuario usuario;

            switch (dto.Tipo.ToLower())
            {
                case "administrador":
                    usuario = new Administrador
                    {
                        Nome = dto.Nome,
                        Email = dto.Email,
                        SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                        Telefone = dto.Telefone,
                        DataCadastro = DateTime.UtcNow,
                        Tipo = dto.Tipo
                    };
                    break;

                case "voluntario":
                    usuario = new Voluntario
                    {
                        Nome = dto.Nome,
                        Email = dto.Email,
                        SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                        Telefone = dto.Telefone,
                        DataCadastro = DateTime.UtcNow,
                        Tipo = dto.Tipo
                    };
                    break;

                case "doador":
                    usuario = new Doador
                    {
                        Nome = dto.Nome,
                        Email = dto.Email,
                        SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                        Telefone = dto.Telefone,
                        DataCadastro = DateTime.UtcNow,
                        Tipo = dto.Tipo
                    };
                    break;

                default:
                    throw new ArgumentException("Tipo de usuário inválido.");
            }

            await _repository.CreateAsync(usuario);

            return _mapper.Map<UsuarioReadDto>(usuario);
        }


        public async Task<bool> UpdateAsync(int id, UsuarioUpdateDto dto)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null) return false;

            _mapper.Map(dto, usuario);
            _repository.Update(usuario);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null) return false;

            _repository.Delete(usuario);
            return await _repository.SaveChangesAsync();
        }
    }
}
