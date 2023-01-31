using InvenLock.Data;
using InvenLock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvenLock.Controllers;

[ApiController]
[Route("[controller]")]
public class OcorrenciasController : ControllerBase
{
    private DataContext _context;
    public OcorrenciasController(DataContext context){_context = context}

    public async Task<IActionResult> AddOcorrenciaAsync(Ocorrencia ocorrencia)
    {
        try
        {
            bool aceito = false;
            string pk = "";
            while(aceito != true)
            {
                pk = Guid.NewGuid().ToString();
                Ocorrencia chave = await _context.Ocorrencias
                    .FirstOrDefaultAsync( x => x.OcorrenciaId == pk);
                if(chave is null) aceito = true;
                else if(chave != null) aceito = false;
            }
            ocorrencia.OcorrenciaId = pk;
            if (ocorrencia.FuncionarioCPF is null)
                throw new Exception("O campo do CPF responsável é obrigatório");
            //A PARTE ABAIXO AINDA ESTA EM ESTE

            Funcionario funcionarioResponsavel = await _context.Funcionarios
                .FirstOrDefaultAsync(cpf => cpf.FuncionarioCPF == ocorrencia.FuncionarioCPF);
            ocorrencia.FuncionarioId = funcionarioResponsavel.FuncionarioId;

            await _context.Ocorrencias.AddAsync(ocorrencia);
            await _context.SaveChangesAsync();

            return Ok(ocorrencia);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }
}
