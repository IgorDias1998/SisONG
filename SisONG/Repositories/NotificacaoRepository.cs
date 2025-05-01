using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly SisONGContext _context;

        public NotificacaoRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notificacao>> GetAllAsync()
        {
            return await _context.Notificacoes.ToListAsync();
        }

        public async Task<Notificacao> GetByIdAsync(int id)
        {
            return await _context.Notificacoes.FindAsync(id);
        }

        public async Task AddAsync(Notificacao notificacao)
        {
            await _context.Notificacoes.AddAsync(notificacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notificacao notificacao)
        {
            _context.Notificacoes.Update(notificacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Notificacao notificacao)
        {
            _context.Notificacoes.Remove(notificacao);
            await _context.SaveChangesAsync();
        }
    }
}
