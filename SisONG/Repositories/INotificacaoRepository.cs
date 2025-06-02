using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Repositories
{
    public interface INotificacaoRepository
    {
        Task<IEnumerable<Notificacao>> GetAllAsync();
        Task<Notificacao> GetByIdAsync(int id);
        Task<List<NotificacaoReadDto>> GetByUserIdAsync(int id);
        Task AddAsync(Notificacao notificacao);
        Task UpdateAsync(Notificacao notificacao);
        Task DeleteAsync(Notificacao notificacao);

        Task<IEnumerable<Usuario>> ObterUsuariosPorPerfil(string perfil);
    }
}
