using InvenLock.Data;
using InvenLock.Models;
using InvenLock.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvenLock.Controllers;

[ApiController]
[Route("[controller]")]
public class OcorrenciasController : ControllerBase
{
    private DataContext _context;
    public OcorrenciasController(DataContext context){_context = context;}

    [HttpPost]
    public async Task<IActionResult> AddOcorrenciaAsync(Ocorrencia ocorrencia)
    {
        try
        {
            if (ocorrencia.FuncionarioCPF is null)
                throw new Exception("O campo do CPF do responsável é obrigatório");
            //A PARTE ABAIXO AINDA ESTA EM ESTE
            VerificaDados verificar = new();
            if(!verificar.RecebeCpf(ocorrencia.FuncionarioCPF))
                throw new Exception("Verifique o CPF");

            //Ocorrencia funcionarioOcorrencia = await _context.Ocorrencias
              //  .Include(c => c.)
                
            //ocorrencia.FuncionarioId = funcionario.FuncionarioId;

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

            await _context.Ocorrencias.AddAsync(ocorrencia);
            await _context.SaveChangesAsync();

            return Ok(ocorrencia);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }

    /*[HttpPost("OcorrenciaAll")]
    public async Task<IActionResult> FuncionariosOcorrencias(string cpf)
    {
        try
        {
            VerificaDados verificar = new();
            if(!verificar.RecebeCpf(cpf))
                return NotFound("Por favor verifique se o CPF foi digitado corretamente");
            Ocorrencia ocorrencias = await _context.Ocorrencias
                .Include(f => f.ConsertoEquip)
                .Include(f => f.ConsertoEquip.Equipamento)
                .Include(f => f.ConsertoEquip.Equipamento.Funcionario)
                .FirstOrDefaultAsync(x => x.FuncionarioId == cpf);
           
            if(ocorrencias is null)
                return NotFound("Nenhum ocorrência com esse CPF foi encontrada!");
            
            return Ok(ocorrencias);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    */

}
