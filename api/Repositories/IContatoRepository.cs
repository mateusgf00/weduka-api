using System;
using api.Models;

namespace api.Repositories
{
	public interface IContatoRepository
	{
        Task Create(Contato contato);
        Task<List<Contato>> FindAll();
        Task<Contato> FindOne(int id);
        Task Update(Contato contato);
        Task Delete(Contato contato);
    }
}

