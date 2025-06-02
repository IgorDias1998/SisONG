using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoService _service;
        private readonly INotificacaoRepository _repository;

        public NotificacaoController(INotificacaoService service, INotificacaoRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notificacoes = await _service.GetAllAsync();
            return Ok(notificacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var notificacao = await _service.GetByIdAsync(id);
            if (notificacao == null) return NotFound();
            return Ok(notificacao);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetByUsuarioId(int usuarioId)
        {
            var notificacoes = await _service.GetByUserIdAsync(usuarioId);
            return Ok(notificacoes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotificacaoCreateDto dto)
        {
            // Buscar todos os usuários com o tipo informado
            var usuarios = await _service.GetAllAsync();
            var destinatarios = usuarios
                .Where(u => u.Tipo.Equals(dto.Tipo, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!destinatarios.Any())
                return BadRequest("Nenhum usuário encontrado com esse tipo.");

            foreach (var usuario in destinatarios)
            {
                await _service.CreateAsync(new NotificacaoCreateDto
                {
                    Tipo = dto.Tipo,
                    Mensagem = dto.Mensagem,
                    DataEnvio = dto.DataEnvio,
                    UsuarioId = usuario.Id
                });
            }
            return Ok();
        }

        [HttpPost("enviar")]
        public async Task<IActionResult> EnviarParaGrupo([FromBody] NotificacaoGrupoDto dto)
        {
            Console.WriteLine($"Recebido: {dto.PerfilDestino} | {dto.Tipo} | {dto.Mensagem}");

            if (string.IsNullOrWhiteSpace(dto.PerfilDestino))
                return BadRequest("Perfil de destino obrigatório.");

            var usuarios = await _repository.ObterUsuariosPorPerfil(dto.PerfilDestino);

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Enviando para usuário: {usuario.Id}");

                var notificacao = new Notificacao
                {
                    UsuarioId = usuario.Id,
                    Tipo = dto.Tipo,
                    Mensagem = dto.Mensagem,
                    DataEnvio = dto.DataEnvio
                };

                await _service.CreateAsync(new NotificacaoCreateDto
                {
                    Tipo = dto.Tipo,
                    Mensagem = dto.Mensagem,
                    DataEnvio = dto.DataEnvio,
                    UsuarioId = usuario.Id
                });
            }

            return Ok("Notificações enviadas com sucesso.");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotificacaoUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
