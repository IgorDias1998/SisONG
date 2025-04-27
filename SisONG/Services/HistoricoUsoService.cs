using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class HistoricoUsoService
    {
        private readonly IHistoricoUsoRepository _repository;
        private readonly IMapper _mapper;

        public HistoricoUsoService(IHistoricoUsoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HistoricoUsoDto> AdicionarAsync(HistoricoUsoCreateDto dto)
        {
            var historico = _mapper.Map<HistoricoUso>(dto);
            await _repository.AddAsync(historico);
            return _mapper.Map<HistoricoUsoDto>(historico);
        }

        public async Task<HistoricoUsoDto> BuscarPorIdAsync(int id)
        {
            var historico = await _repository.GetByIdAsync(id);
            return _mapper.Map<HistoricoUsoDto>(historico);
        }

        public async Task<IEnumerable<HistoricoUsoDto>> BuscarTodosAsync()
        {
            var historicos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<HistoricoUsoDto>>(historicos);
        }
    }
}
