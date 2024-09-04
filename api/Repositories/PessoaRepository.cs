using System;
using api.DataContext;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
	public class PessoaRepository: IPessoaRepository
	{
		private readonly ApplicationDbContext _context;

		public PessoaRepository(ApplicationDbContext context)
		{
			_context = context;

		}

        public async Task Create(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pessoa>> FindAll()
        {
            return await _context.Pessoas.Include(p => p.Contatos).ToListAsync();
        }

        public async Task<Pessoa> FindOne(int id)
        {
            return await _context.Pessoas.Include(p => p.Contatos).FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task Update(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Pessoa pessoa)
        {

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
  
        }
    }
}

