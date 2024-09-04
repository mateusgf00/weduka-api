using System;
using api.Models;

namespace api.Repositories
{
	public interface IPessoaRepository
	{
        Task Create(Pessoa pessoa);
        Task<List<Pessoa>> FindAll();
        Task<Pessoa> FindOne(int id);
        Task Update(Pessoa pessoa);
        Task Delete(Pessoa pessoa);
    }
}

