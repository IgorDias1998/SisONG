using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoVoluntarioController : ControllerBase
    {
        private readonly IEventoVoluntarioService _service;

        public EventoVoluntarioController(IEventoVoluntarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVoluntarioEvento([FromBody] EventoVoluntarioCreateDto dto)
        {
            try
            {
                await _service.AddAsync(dto);
                return Ok("Voluntário cadastrado com sucesso no evento.");
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar o voluntário no evento.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverVoluntarioEvento(int eventoId, int voluntarioId)
        {
            var resultado = await _service.RemoveAsync(eventoId, voluntarioId);
            if (!resultado)
                return NotFound("Relacionamento não encontrado.");

            return NoContent();
        }

        [HttpGet("evento/{eventoId}")]
        public async Task<ActionResult<IEnumerable<EventoVoluntarioReadDto>>> ListarVoluntariosPorEvento(int eventoId)
        {
            var voluntarios = await _service.GetByEventoIdAsync(eventoId);
            return Ok(voluntarios);
        }

        [HttpGet("voluntario/{voluntarioId}")]
        public async Task<ActionResult<IEnumerable<EventoVoluntarioReadDto>>> ListarEventosPorVoluntario(int voluntarioId)
        {
            var eventos = await _service.GetByVoluntarioIdAsync(voluntarioId);
            return Ok(eventos);
        }

    }
}
