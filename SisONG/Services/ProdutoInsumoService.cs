using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class ProdutoInsumoService : IProdutoInsumoService
    {
        private readonly IProdutoInsumoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoInsumoService(IProdutoInsumoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoInsumoReadDto>> GetAllAsync()
        {
            var produtos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoInsumoReadDto>>(produtos);
        }

        public async Task<ProdutoInsumoReadDto> GetByIdAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            return produto == null ? null : _mapper.Map<ProdutoInsumoReadDto>(produto);
        }

        public async Task<ProdutoInsumoReadDto> CreateAsync(ProdutoInsumoCreateDto dto)
        {
            var produto = _mapper.Map<ProdutoInsumo>(dto);
            await _repository.CreateAsync(produto);
            await _repository.SaveChangesAsync();
            return _mapper.Map<ProdutoInsumoReadDto>(produto);
        }

        public async Task<bool> UpdateAsync(int id, ProdutoInsumoUpdateDto dto)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null) return false;

            _mapper.Map(dto, produto);
            await _repository.UpdateAsync(produto);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null) return false;

            await _repository.DeleteAsync(produto);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
