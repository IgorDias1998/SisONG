using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Services;

namespace SisONG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoFinanceiraController : ControllerBase
    {
        private readonly ITransacaoFinanceiraService _service;

        public TransacaoFinanceiraController(ITransacaoFinanceiraService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoFinanceiraReadDto>>> GetAll()
        {
            var transacoes = await _service.GetAllAsync();
            return Ok(transacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransacaoFinanceiraReadDto>> GetById(int id)
        {
            var transacao = await _service.GetByIdAsync(id);

            if (transacao == null)
                return NotFound();

            return Ok(transacao);
        }

        [HttpPost]
        public async Task<ActionResult<TransacaoFinanceiraReadDto>> Create(TransacaoFinanceiraCreateDto createDto)
        {
            var novaTransacao = await _service.AddAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = novaTransacao.Id }, novaTransacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TransacaoFinanceiraReadDto>> Update(int id, TransacaoFinanceiraUpdateDto updateDto)
        {
            var transacaoAtualizada = await _service.UpdateAsync(id, updateDto);

            if (transacaoAtualizada == null)
                return NotFound();

            return Ok(transacaoAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _service.DeleteAsync(id);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
