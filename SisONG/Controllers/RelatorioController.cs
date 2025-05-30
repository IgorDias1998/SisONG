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

        // GET: api/Relatorio
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var relatorios = await _relatorioService.GetAllAsync();
            return Ok(relatorios);
        }

        // GET: api/Relatorio/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var relatorio = await _relatorioService.GetByIdAsync(id);
            if (relatorio == null)
                return NotFound();

            return Ok(relatorio);
        }

        // POST: api/Relatorio
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RelatorioRequestDto requestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdRelatorio = await _relatorioService.AddAsync(requestDto);
            return CreatedAtAction(nameof(GetById), new { id = createdRelatorio.Id }, createdRelatorio);
        }

        // PUT: api/Relatorio/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RelatorioUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedRelatorio = await _relatorioService.UpdateAsync(id, updateDto);
            if (updatedRelatorio == null)
                return NotFound();

            return Ok(updatedRelatorio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _relatorioService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GerarPdf(int id, [FromServices] RelatorioPdfService pdfGenerator)
        {
            var relatorio = await _relatorioService.GetByIdAsync(id);
            if (relatorio == null)
                return NotFound();

            var pdfBytes = pdfGenerator.GerarPdf(relatorio);
            return File(pdfBytes, "application/pdf", $"relatorio_{id}.pdf");
        }

    }
}
