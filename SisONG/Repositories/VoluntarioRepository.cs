using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Models;
using System;

namespace SisONG.Repositories
{
    public class VoluntarioRepository : IVoluntarioRepository
    {
        private readonly SisONGContext _context;

        public VoluntarioRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Voluntario>> GetAllAsync()
        {
            return await _context.Voluntarios.ToListAsync();
        }

        public async Task<Voluntario> GetByIdAsync(int id)
        {
            return await _context.Voluntarios.FindAsync(id);
        }

        public async Task CreateAsync(Voluntario voluntario)
        {
            await _context.Voluntarios.AddAsync(voluntario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Voluntario voluntario)
        {
            _context.Voluntarios.Update(voluntario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Voluntario voluntario)
        {
            _context.Voluntarios.Remove(voluntario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Voluntarios.AnyAsync(v => v.Id == id);
        }
    }
}
