using SisONG.Models;
using SisONG.Data.Context;
using System;
using Microsoft.EntityFrameworkCore;

namespace SisONG.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly SisONGContext _context;

        public DoadorRepository(SisONGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doador>> GetAllAsync()
        {
            return await _context.Doadores.ToListAsync();
        }

        public async Task<Doador> GetByIdAsync(int id)
        {
            return await _context.Doadores.FindAsync(id);
        }

        public async Task CreateAsync(Doador doador)
        {
            await _context.Doadores.AddAsync(doador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doador doador)
        {
            _context.Doadores.Update(doador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Doador doador)
        {
            _context.Doadores.Remove(doador);
            await _context.SaveChangesAsync();
        }
    }
}
