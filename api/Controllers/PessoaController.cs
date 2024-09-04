using System;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/pessoas")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Pessoa>>>> Create(CreatePessoaDto pessoa)
    {
        return Ok(await _pessoaService.Create(pessoa));
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Pessoa>>>> FindAll()
    {
        return Ok(await _pessoaService.FindAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Pessoa>>> FindOne(int id)
    {
        return Ok(await _pessoaService.FindOne(id));
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<Pessoa>>> Update(int id, UpdatePessoaDto pessoa)
    {
        return Ok(await _pessoaService.Update(id, pessoa));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<Pessoa>>> DeletePessoa(int id)
    {
        return Ok(await _pessoaService.Delete(id));
    }
}


