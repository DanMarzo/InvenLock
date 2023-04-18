using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvenLock.Models;

public class EquipamentoEmprestimo
{
    public int FuncionarioId { get; set; }
    [JsonIgnore]
    public Funcionario Funcionario { get; set; }
    public string FuncionarioEntregadorCpf { get; set; }
    public int CodigoInterno { get; set; }
    [JsonIgnore]
    public string EquipamentoId { get; set; }
    [JsonIgnore]
    public Equipamento Equipamento { get; set; }
    public DateTime? DataEmprestimo { get; set; }
    public DateTime? DataDevolucao { get; set; }
}
