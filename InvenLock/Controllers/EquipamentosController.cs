using InvenLock.Data;
using InvenLock.Models;
using Microsoft.AspNetCore.Mvc;

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

            return Ok(equipamento);
            //return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
