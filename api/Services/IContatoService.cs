using System;
using api.Models;

namespace api.Services
{
	public interface IContatoService
	{
        Task<ServiceResponse<Contato>> Create(CreateContatoDto newContato);
        Task<ServiceResponse<List<Contato>>> FindAll();
        Task<ServiceResponse<Contato>> FindOne(int id);
        Task<ServiceResponse<Contato>> Update(int id, UpdateContatoDto updatedPessoa);
        Task<ServiceResponse<Contato>> Delete(int id);
    }
}

