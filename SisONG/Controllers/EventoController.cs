using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _service;

        public EventoController(IEventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoReadDto>>> GetAll()
        {
            var eventos = await _service.GetAllAsync();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventoReadDto>> GetById(int id)
        {
            var evento = await _service.GetByIdAsync(id);
            if (evento == null)
                return NotFound();

            return Ok(evento);
        }

        [HttpPost]
        public async Task<ActionResult<EventoReadDto>> Create(EventoCreateDto dto)
        {
            var evento = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventoUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

    }
}
