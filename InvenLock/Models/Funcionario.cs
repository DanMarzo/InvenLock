
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using InvenLock.Models.Enums.Funcionario;

namespace InvenLock.Models;

public class Funcionario
{
    [Column(TypeName = "varchar(70)")]
    public string FuncionarioId { get; set; }   
    public string NomeFuncionario { get; set; }
    public string SobreNomeFuncionario { get; set; }
    public string FuncionarioCPF { get; set; }
    public DateTime? DataAdmissao { get; set; }
    public DateTime? DataDemissao { get; set; }
    public bool? Ativo { get; set; }
    public FuncionarioCargo FuncionarioCargo { get; set; }
    [JsonIgnore]
    public ICollection<Equipamento> Equipamentos { get; set; }
}
