using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using InvenLock.Data;
using InvenLock.Models;
using Microsoft.AspNetCore.Mvc;

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
}
