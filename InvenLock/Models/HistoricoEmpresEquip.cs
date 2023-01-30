using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class HistoricoEmpresEquip
{
    public int HistoricoEmpresEquipId { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DateDevolucao { get; set;}
    [Column(TypeName ="varchar(40)")]
    public string EquipamentoId { get; set; }
    [Column(TypeName ="varchar(40)")]
    public string FuncionarioId { get; set; }
    [JsonIgnore]
    public Funcionario Funcionario { get; set; }
}
