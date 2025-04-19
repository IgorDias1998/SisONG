using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;

namespace SisONG.Repositories
{
    public class AdministradorRepository  : IAdministradorRepository
    {
        private readonly SisONGContext _context;

        public AdministradorRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Administrador>> GetAllAsync()
        {
            return await _context.Administradores.ToListAsync();
        }

        public async Task<Administrador> GetByIdAsync(int id)
        {
            return await _context.Administradores.FindAsync(id);
        }

        public async Task CreateAsync(Administrador administrador)
        {
            await _context.Administradores.AddAsync(administrador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Administrador administradorr)
        {
            _context.Administradores.Update(administradorr);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Administrador administrador)
        {
            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
        }

    }
}
