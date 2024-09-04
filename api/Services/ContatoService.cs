using api.Models;
using api.Repositories;

namespace api.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<ServiceResponse<Contato>> Create(CreateContatoDto newContato)
        {
            ServiceResponse<Contato> serviceResponse = new ServiceResponse<Contato>();

            try
            {
                if (newContato == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Contato não pode ser nulo";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                var contato = new Contato
                {
                    Tipo = newContato.Tipo,
                    Valor = newContato.Valor,
                    PessoaId = newContato.PessoaId
                };

                await _contatoRepository.Create(contato);

                serviceResponse.Dados = contato;
                serviceResponse.Mensagem = "Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<Contato>>> FindAll()
        {
            ServiceResponse<List<Contato>> serviceResponse = new ServiceResponse<List<Contato>>();

            try
            {
                serviceResponse.Dados = await _contatoRepository.FindAll();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum contato encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Contato>> FindOne(int id)
        {
            ServiceResponse<Contato> serviceResponse = new ServiceResponse<Contato>();

            try
            {
                Contato contato = await _contatoRepository.FindOne(id);

                if (contato == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Contato não encontrado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = contato;

            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Contato>> Update(int id, UpdateContatoDto updatedPessoa)
        {
            ServiceResponse<Contato> serviceResponse = new ServiceResponse<Contato>();

            try
            {
                Contato contatoExistente = await _contatoRepository.FindOne(id);

                if (contatoExistente == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Contato não encontrado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                contatoExistente.Tipo = updatedPessoa.Tipo != null ? updatedPessoa.Tipo : contatoExistente.Tipo;
                contatoExistente.Valor = updatedPessoa.Valor != null ? updatedPessoa.Valor : contatoExistente.Valor;

                await _contatoRepository.Update(contatoExistente);

                serviceResponse.Mensagem = "atualizado com sucesso!";

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Contato>> Delete(int id)
        {
            ServiceResponse<Contato> serviceResponse = new ServiceResponse<Contato>();

            try
            {
                Contato contato = await _contatoRepository.FindOne(id);

                if (contato == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Contato não encontrado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }


                await _contatoRepository.Delete(contato);


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

