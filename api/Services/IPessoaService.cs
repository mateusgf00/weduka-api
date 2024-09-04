using System;
using api.Models;

namespace api.Services
{
	public interface IPessoaService
	{
		Task<ServiceResponse<Pessoa>> Create(CreatePessoaDto newPessoa);
		Task<ServiceResponse<List<Pessoa>>> FindAll();
		Task<ServiceResponse<Pessoa>> FindOne(int id);
		Task<ServiceResponse<Pessoa>> Update(int id, UpdatePessoaDto updatedPessoa);
		Task<ServiceResponse<Pessoa>> Delete(int id);
    }
}

