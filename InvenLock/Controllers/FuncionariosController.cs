using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Azure.Core;
using InvenLock.Data;
using InvenLock.Models;
using InvenLock.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace InvenLock.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionariosController : ControllerBase
{
    private DataContext _context;
    public FuncionariosController(DataContext context){_context = context;}

    [HttpPost]
    public async Task<IActionResult> AddFuncionarioAsync(Funcionario funcionario)
    {
        try
        {
            
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync(); 

            return Ok(funcionario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> DesativarAtivaFuncionarioAsync(Funcionario funcionario)
    {
        try
        {
           
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);            
        }
    }

    [HttpGet]
    public async Task<IActionResult> TudoAsync()
    {
        List<Funcionario> todos = await _context.Funcionarios.ToListAsync();
        if(todos is null)
            return NotFound("Nenhum funcionario cadastrado");
        return Ok(todos);
    }

    [HttpPost("BuscaCPF")]
    public async Task<IActionResult> BuscaPorCFF(string cpf)
    {
        try
        {
            VerificaDados verificaDados =
                cpf is null ?
                throw new Exception("CPF Não pode ser nulo")
                : new();
            cpf = verificaDados.ConsertaCpf(cpf);

            Funcionario existeFun =
                !verificaDados.RecebeCpf(cpf) ?
                throw new Exception("Verifique o CPF inserido")
                : await _context.Funcionarios
                .FirstOrDefaultAsync(x => x.CPF == cpf);

            if (existeFun != null) return Ok(existeFun);
            return NotFound(($"CPF: {cpf} não encontrado"));
            
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Contato")]
    public async Task<IActionResult> ContatosAsync(ContatoFuncionario contatoFuncionario)
    {
        try
        {
           


            await _context.ContatoFuncionarios.AddAsync(contatoFuncionario);
            int linhasAfetadas =  await _context.SaveChangesAsync();

            return Ok(linhasAfetadas);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
