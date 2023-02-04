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
            VerificaDados verifica = funcionario is null || funcionario.FuncionarioCPF is null ?
                throw new Exception("Verifique os campos obrigatorios")
                : new();

            funcionario.FuncionarioCPF = verifica.ConsertaCpf(funcionario.FuncionarioCPF);

            Funcionario confirmaCpf = !verifica.RecebeCpf(funcionario.FuncionarioCPF) ?
                throw new Exception("Verifique o CPF")
                : await _context.Funcionarios
                .FirstOrDefaultAsync(x => x.FuncionarioCPF == funcionario.FuncionarioCPF);

            if(confirmaCpf != null)
                throw new Exception("CPF já esta sendo utilizado");

            bool aceito = false;
            string pk = "";
            while(aceito != true)
            {
                pk = Guid.NewGuid().ToString();
                Funcionario chave = _context.Funcionarios.FirstOrDefault( x => x.FuncionarioId == pk);
                if(chave is null) aceito = true;
                else if(chave != null) aceito = false;
            }
            funcionario.FuncionarioId = pk;

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
            VerificaDados verifica = funcionario.Ativo is null || funcionario.FuncionarioCPF is null ?
                throw new Exception("Campos Obrigatorios")
                : new();

            funcionario.FuncionarioCPF = verifica.ConsertaCpf(funcionario.FuncionarioCPF);

            Funcionario consulta = !verifica.RecebeCpf(funcionario.FuncionarioCPF) ? 
                throw new Exception("Verifique o CPF informado")
                : await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.FuncionarioCPF == funcionario.FuncionarioCPF);

            if (consulta is null) return NotFound("Funcionario não encontrado");

            consulta.Ativo = funcionario.Ativo;

            if(consulta.Ativo == false)
                consulta.DataDemissao = DateTime.Now;
            else
            {
                consulta.DataAdmissao = DateTime.Now;
                consulta.DataDemissao = null; //Olha eu sei que isso ta estranho kkkk, mas, logo a frente eu penso em criar uma tabela para esse tipo de registro
            }
            string fraseSaida = consulta.Ativo == false ?
                $"{consulta.NomeFuncionario} desligado com sucesso! Na data {consulta.DataDemissao}" 
                : $"{consulta.NomeFuncionario} ativo com sucesso! Na data {consulta.DataAdmissao}";
            
            _context.Funcionarios.Update(consulta);
            await _context.SaveChangesAsync();

            return Ok(fraseSaida);
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
                .FirstOrDefaultAsync(x => x.FuncionarioCPF == cpf);

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
            VerificaDados verificaDados = 
                contatoFuncionario.CPF is null ? 
                throw new Exception("CPF Não pode ser nulo") 
                : new();

            contatoFuncionario.CPF = verificaDados.ConsertaCpf(contatoFuncionario.CPF);

            Funcionario existeFun =
                !verificaDados.RecebeCpf(contatoFuncionario.CPF) ?
                throw new Exception("Verifique o CPF inserido")
                : await _context.Funcionarios
                .FirstOrDefaultAsync(x => x.FuncionarioCPF == contatoFuncionario.CPF);

            if (existeFun is null) return NotFound("CPF não cadastrado");
            if (existeFun.Ativo == false) throw new Exception("Funcionario inativo");

            contatoFuncionario.FuncionarioId = existeFun.FuncionarioId;

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
