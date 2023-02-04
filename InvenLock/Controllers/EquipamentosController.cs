using InvenLock.Data;
using InvenLock.Models;
using InvenLock.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvenLock.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipamentosController : ControllerBase
{
    private DataContext _context;
    public EquipamentosController(DataContext context){_context = context;}

    [HttpPost]
    public async Task<IActionResult> AddEquipamentoAsync(Equipamento equipamento)
    {
        try
        {
            VerificaDados verifica = equipamento.MarcaEquipamento is null || equipamento.FuncionarioRecebedor is null ?
                throw new Exception("Verifique os campos obrigatorios")
                : new();

            equipamento.FuncionarioRecebedor = verifica.ConsertaCpf(equipamento.FuncionarioRecebedor);

            Funcionario existeFunc = !verifica.RecebeCpf(equipamento.FuncionarioRecebedor) ?
                throw new Exception("Verifique o CPF")
                : await _context.Funcionarios.FirstOrDefaultAsync(x => x.FuncionarioCPF == equipamento.FuncionarioRecebedor);

            if (existeFunc is null) return NotFound("Funcionario não cadastrado na empresa");
            if (existeFunc.Ativo is false) throw new Exception("Funcionario está inativo");

            bool aceito = false;
            string pk = "";
            while(aceito != true)
            {
                pk = Guid.NewGuid().ToString();
                Equipamento chave = _context.Equipamentos.FirstOrDefault( x => x.EquipamentoId == pk);
                if(chave is null) aceito = true;
                else if(chave != null) aceito = false;
            }
            equipamento.EquipamentoId = pk;

            await _context.Equipamentos.AddAsync(equipamento);
            await _context.SaveChangesAsync(); 

            return Ok($"Codigo Interno: {equipamento.CodigoInterno}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
