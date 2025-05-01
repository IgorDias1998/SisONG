using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacaoController : ControllerBase
    {
        private readonly INotificacaoService _service;

        public NotificacaoController(INotificacaoService service)
        {
            _service = service;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotificacaoCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
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
