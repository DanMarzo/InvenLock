using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvenLock.Models;

public class EquipamentoEmprestimo
{
    [Column(TypeName = "varchar(70)")]
    public string FuncionarioId { get; set; }
    public Funcionario Funcionarios { get; set; }
    public string EquipamentoId { get; set; }
    [JsonIgnore]
    public Equipamento Equipamento { get; set; }
    public DateTime? DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }
}
