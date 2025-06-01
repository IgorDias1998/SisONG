using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoacaoController : ControllerBase
    {
        private readonly IDoacaoService _service;

        public DoacaoController(IDoacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoacaoReadDto>>> GetAll()
        {
            var doacoes = await _service.GetAllAsync();
            return Ok(doacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoacaoReadDto>> GetById(int id)
        {
            var doacao = await _service.GetByIdAsync(id);
            if (doacao == null) return NotFound();
            return Ok(doacao);
        }

        [HttpGet("doador/{doadorId}")]
        public async Task<ActionResult<IEnumerable<DoacaoReadDto>>> ListarPorDoador(int doadorId)
        {
            var doacoes = await _service.GetByDoadorIdAsync(doadorId);
            return Ok(doacoes);
        }

        [HttpPost]
        public async Task<ActionResult<DoacaoReadDto>> Create(DoacaoCreateDto dto)
        {
            var novaDoacao = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = novaDoacao.Id }, novaDoacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, DoacaoUpdateDto dto)
        {
            var sucesso = await _service.UpdateAsync(id, dto);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sucesso = await _service.DeleteAsync(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }

        [HttpGet("total")]
        public async Task<ActionResult<decimal>> ObterTotalDoacoes()
        {
            var total = await _service.ObterTotalDoacoesAsync();
            return Ok(total);
        }
    }
}
