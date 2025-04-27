using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoricoUsoController : ControllerBase
    {
        private readonly HistoricoUsoService _service;

        public HistoricoUsoController(HistoricoUsoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HistoricoUsoCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoHistorico = await _service.AdicionarAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = novoHistorico.Id }, novoHistorico);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoUsoDto>> GetById(int id)
        {
            var historico = await _service.BuscarPorIdAsync(id);

            if (historico == null)
                return NotFound();

            return Ok(historico);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoUsoDto>>> GetAll()
        {
            var historicos = await _service.BuscarTodosAsync();
            return Ok(historicos);
        }
    }
}
