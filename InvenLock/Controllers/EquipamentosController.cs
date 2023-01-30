using InvenLock.Data;
using InvenLock.Models;
using InvenLock.Utils;
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
            if(equipamento is null)
                throw new Exception("Dados do equipamento não poder ser vazio");
            ChavesPK pk = new();

            if(!((int)equipamento.TipoEquip > 0 && (int)equipamento.TipoEquip <4 ))
                throw new Exception("Tipo do Equipamento invalido!");
            equipamento.EquipamentoId = pk.GeradorPK(1);
            
            await _context.Equipamentos.AddAsync(equipamento);
            await _context.SaveChangesAsync(); 

            return Ok(equipamento);
            //return new CreatedAtRouteResult();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
