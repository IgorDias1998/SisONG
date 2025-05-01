using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PontoColetaController : ControllerBase
    {
        private readonly IPontoColetaService _service;

        public PontoColetaController(IPontoColetaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pontos = await _service.GetAllAsync();
            return Ok(pontos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ponto = await _service.GetByIdAsync(id);
            if (ponto == null) return NotFound();
            return Ok(ponto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PontoColetaCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PontoColetaUpdateDto dto)
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
