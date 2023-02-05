
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using InvenLock.Models.Enums.Funcionario;

namespace InvenLock.Models;

public class Funcionario
{
    [JsonIgnore]
    [Column(TypeName = "varchar(70)")]
    public string FuncionarioId { get; set; }   
    public string NomeFuncionario { get; set; }
    public string SobreNomeFuncionario { get; set; }
    public string FuncionarioCPF { get; set; }
    public int NumOcorrencias { get; set; }
    public DateTime? DataAdmissao { get; set; }
    public DateTime? DataDemissao { get; set; }
    public bool? Ativo { get; set; }
    public FuncionarioCargo FuncionarioCargo { get; set; }
    [JsonIgnore]
    public ICollection<Ocorrencia> Ocorrencia { get; set; }
    [JsonIgnore]
    public ContatoFuncionario ContatoFuncionario { get; set; }
    [JsonIgnore]
    public EnderecoFuncionario EnderecoFuncionario { get; set; }
    [JsonIgnore]
    public ICollection<EquipamentoEmprestimo> EquipamentoEmprestimos { get; set; }
}
