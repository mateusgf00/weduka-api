using System;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/contatos")]
public class ContatoController : ControllerBase
{
    private readonly IContatoService _contatoService;

    public ContatoController(IContatoService contatoService)
    {
        _contatoService = contatoService;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Contato>>> Create(CreateContatoDto contato)
    {
        return Ok(await _contatoService.Create(contato));
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Contato>>>> FindAll()
    {
        return Ok(await _contatoService.FindAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Contato>>> FindOne(int id)
    {
        return Ok(await _contatoService.FindOne(id));
    }



    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Contato>>> Update(int id, UpdateContatoDto contato)
    {
        return Ok(await _contatoService.Update(id, contato));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Contato>>> DeletePessoa(int id)
    {
        return Ok(await _contatoService.Delete(id));
    }
}


