using SisONG.Models;

namespace SisONG.Repositories
{
    public interface INotificacaoRepository
    {
        Task<IEnumerable<Notificacao>> GetAllAsync();
        Task<Notificacao> GetByIdAsync(int id);
        Task AddAsync(Notificacao notificacao);
        Task UpdateAsync(Notificacao notificacao);
        Task DeleteAsync(Notificacao notificacao);
    }
}
