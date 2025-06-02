using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.DTOs;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly SisONGContext _context;
        private readonly IMapper _mapper;

        public NotificacaoRepository(SisONGContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Notificacao>> GetAllAsync()
        {
            return await _context.Notificacoes.ToListAsync();
        }

        public async Task<Notificacao> GetByIdAsync(int id)
        {
            return await _context.Notificacoes.FindAsync(id);
        }

        public async Task<List<NotificacaoReadDto>> GetByUserIdAsync(int usuarioId)
        {
            var notificacoes = await _context.Notificacoes
                .Where(n => n.UsuarioId == usuarioId)
                .OrderByDescending(n => n.DataEnvio)
                .ToListAsync();

            return _mapper.Map<List<NotificacaoReadDto>>(notificacoes);
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

        public async Task<IEnumerable<Usuario>> ObterUsuariosPorPerfil(string perfil)
        {
            return await _context.Usuarios
                .Where(u => u.Tipo == perfil)
                .ToListAsync();
        }
    }
}
