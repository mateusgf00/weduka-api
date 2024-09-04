using api.Models;
using api.Repositories;

namespace api.Services
{
	public class PessoaService : IPessoaService
	{
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IContatoService _contatoService;

        public PessoaService(IPessoaRepository pessoaRepository, IContatoService contatoService)
        {
            _pessoaRepository = pessoaRepository;
            _contatoService = contatoService;
        }

        public async Task<ServiceResponse<Pessoa>> Create(CreatePessoaDto newPessoa)
        {
            ServiceResponse<Pessoa> serviceResponse = new ServiceResponse<Pessoa>();

            try
            {
                if (newPessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não pode ser nula";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                var pessoa = new Pessoa
                {
                    Nome = newPessoa.Nome
                };

                await _pessoaRepository.Create(pessoa);

                foreach (var contatoDto in newPessoa.Contatos)
                {
                    var contato = new CreateContatoDto
                    {
                        Tipo = contatoDto.Tipo,
                        Valor = contatoDto.Valor,
                        PessoaId = pessoa.Id
                    };

                    await _contatoService.Create(contato);
                }

                serviceResponse.Dados = pessoa;
                serviceResponse.Mensagem = "Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Pessoa>>> FindAll()
        {
            ServiceResponse<List<Pessoa>> serviceResponse = new ServiceResponse<List<Pessoa>>();

            try
            {
                serviceResponse.Dados = await _pessoaRepository.FindAll();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhuma Pessoa encontrada!";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Pessoa>> FindOne(int id)
        {
            ServiceResponse<Pessoa> serviceResponse = new ServiceResponse<Pessoa>();

            try
            {
                Pessoa pessoa = await _pessoaRepository.FindOne(id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não encontrada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = pessoa;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<Pessoa>> Update(int id, UpdatePessoaDto updatedPessoa)
        {
            ServiceResponse<Pessoa> serviceResponse = new ServiceResponse<Pessoa>();

            try
            {
                Pessoa pessoaExistente = await _pessoaRepository.FindOne(id);

                if (pessoaExistente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não encontrada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                pessoaExistente.Nome = updatedPessoa.Nome;

                await _pessoaRepository.Update(pessoaExistente);

                serviceResponse.Mensagem = "atualizado com sucesso!";
                serviceResponse.Dados = pessoaExistente;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Pessoa>> Delete(int id)
        {
            ServiceResponse<Pessoa> serviceResponse = new ServiceResponse<Pessoa>();

            try
            {
                Pessoa pessoa = await _pessoaRepository.FindOne(id);

                if (pessoa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pessoa não encontrada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                await _pessoaRepository.Delete(pessoa);


                serviceResponse.Mensagem = "Deletado com sucesso!";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}

