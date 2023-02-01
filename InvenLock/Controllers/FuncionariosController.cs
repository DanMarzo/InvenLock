using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using InvenLock.Data;
using InvenLock.Models;
using InvenLock.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            VerificaDados verifica = new();
            if(!verifica.RecebeCpf(funcionario.FuncionarioCPF))
                throw new Exception("Verifique o CPF");
            Funcionario confirmaCpf = await _context.Funcionarios
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
            if(funcionario is null || funcionario.FuncionarioCPF is null)
                throw new Exception("O mesmo não pode ser nulo");
            
            VerificaDados verifica = new();

            if(!verifica.RecebeCpf(funcionario.FuncionarioCPF))
                throw new Exception("Verifique o CPF informado");
            
            Funcionario consulta = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.FuncionarioCPF == funcionario.FuncionarioCPF);
            
            if(consulta is null)
                return NotFound("Funcionario não encontrado");

            //Como provavelmente no app que vai consumir vai usar um dropdown entao isso talvez nem funcione kkk
            if(funcionario.Ativo == consulta.Ativo)
                throw new Exception("Você esta tentando mudar a situação para a mesma atual");

            consulta.Ativo = funcionario.Ativo;

            if(consulta.Ativo == false)
                consulta.DataDemissao = DateTime.Now;
            else
            {
                consulta.DataAdmissao = DateTime.Now;
                consulta.DataDemissao = null; //Olha eu sei que isso ta estranho kkkk, mas, logo a frente eu penso em criar uma tabela para esse tipo de registro
            }
            string fraseSaida = consulta.Ativo == false ?
                $"{consulta.NomeFuncionario} desligado com sucesso! Na data {consulta.DataDemissao}" : $"{consulta.NomeFuncionario} ativo com sucesso! Na data {consulta.DataAdmissao}";
            
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
}
