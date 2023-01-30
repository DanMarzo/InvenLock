using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class HistoricoEmpresEquip
{
    public int HistoricoEmpresEquipId { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DateDevolucao { get; set;}
    public string EquipamentoId { get; set; }
    public string FuncionarioId { get; set; }
    [JsonIgnore]
    public Funcionario Funcionario { get; set; }
}
