using AutoMapper;
using SisONG.DTOs;
using SisONG.Models;
using SisONG.Repositories;

namespace SisONG.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IMapper _mapper;

        public RelatorioService(IRelatorioRepository relatorioRepository, IMapper mapper)
        {
            _relatorioRepository = relatorioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RelatorioReadDto>> GetAllAsync()
        {
            var relatorios = await _relatorioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RelatorioReadDto>>(relatorios);
        }

        public async Task<RelatorioReadDto> GetByIdAsync(int id)
        {
            var relatorio = await _relatorioRepository.GetByIdAsync(id);
            return _mapper.Map<RelatorioReadDto>(relatorio);
        }

        public async Task<RelatorioReadDto> AddAsync(RelatorioCreateDto createDto)
        {
            var relatorio = _mapper.Map<Relatorio>(createDto);
            await _relatorioRepository.AddAsync(relatorio);
            return _mapper.Map<RelatorioReadDto>(relatorio);
        }

        public async Task<RelatorioReadDto> UpdateAsync(int id, RelatorioUpdateDto updateDto)
        {
            var relatorioExistente = await _relatorioRepository.GetByIdAsync(id);
            if (relatorioExistente == null)
                return null;

            _mapper.Map(updateDto, relatorioExistente);
            await _relatorioRepository.UpdateAsync(relatorioExistente);

            return _mapper.Map<RelatorioReadDto>(relatorioExistente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var relatorio = await _relatorioRepository.GetByIdAsync(id);
            if (relatorio == null)
                return false;

            await _relatorioRepository.DeleteAsync(relatorio);
            return true;
        }
    }
}
