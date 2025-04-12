using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoluntarioController : ControllerBase
    {
        private readonly IVoluntarioService _service;

        public VoluntarioController(IVoluntarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var voluntarios = await _service.GetAllAsync();
            return Ok(voluntarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var voluntario = await _service.GetByIdAsync(id);
            if (voluntario == null) return NotFound();
            return Ok(voluntario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VoluntarioCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VoluntarioUpdateDto dto)
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
