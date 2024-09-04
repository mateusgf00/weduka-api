using System;
using api.DataContext;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
	public class ContatoRepository: IContatoRepository
	{
		private readonly ApplicationDbContext _context;

		public ContatoRepository(ApplicationDbContext context)
		{
			_context = context;

		}

        public async Task Create(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contato>> FindAll()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<Contato> FindOne(int id)
        {
            return await _context.Contatos.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task Update(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Contato contato)
        {

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
  
        }
    }
}

