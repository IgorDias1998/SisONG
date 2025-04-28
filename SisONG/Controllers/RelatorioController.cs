using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Services;

namespace SisONG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relatorios = await _relatorioService.GetAllAsync();
            return Ok(relatorios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var relatorio = await _relatorioService.GetByIdAsync(id);
            if (relatorio == null)
                return NotFound();

            return Ok(relatorio);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RelatorioCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var relatorioCriado = await _relatorioService.AddAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = relatorioCriado.Id }, relatorioCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RelatorioUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var relatorioAtualizado = await _relatorioService.UpdateAsync(id, updateDto);
            if (relatorioAtualizado == null)
                return NotFound();

            return Ok(relatorioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _relatorioService.DeleteAsync(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
