using SisONG.Models;

namespace SisONG.Repositories
{
    public interface IAdministradorRepository
    {
        Task<IEnumerable<Administrador>> GetAllAsync();
        Task<Administrador> GetByIdAsync(int id);
        Task CreateAsync(Administrador administrador);
        Task UpdateAsync(Administrador administrador);
        Task DeleteAsync(Administrador administrador);

    }
}
