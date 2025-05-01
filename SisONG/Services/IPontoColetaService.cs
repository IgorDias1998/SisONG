using SisONG.DTOs;

namespace SisONG.Services
{
    public interface IPontoColetaService
    {
        Task<IEnumerable<PontoColetaReadDto>> GetAllAsync();
        Task<PontoColetaReadDto> GetByIdAsync(int id);
        Task<PontoColetaReadDto> CreateAsync(PontoColetaCreateDto dto);
        Task<bool> UpdateAsync(int id, PontoColetaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
