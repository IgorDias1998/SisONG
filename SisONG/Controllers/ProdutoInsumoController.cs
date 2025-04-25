using Microsoft.AspNetCore.Mvc;
using SisONG.DTOs;
using SisONG.Services;

namespace SisONG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoInsumoController : ControllerBase
    {
        private readonly IProdutoInsumoService _service;

        public ProdutoInsumoController(IProdutoInsumoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoInsumoReadDto>>> GetAll()
        {
            var produtos = await _service.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoInsumoReadDto>> GetById(int id)
        {
            var produto = await _service.GetByIdAsync(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoInsumoReadDto>> Create(ProdutoInsumoCreateDto dto)
        {
            var novoProduto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProdutoInsumoUpdateDto dto)
        {
            var atualizado = await _service.UpdateAsync(id, dto);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.DeleteAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
