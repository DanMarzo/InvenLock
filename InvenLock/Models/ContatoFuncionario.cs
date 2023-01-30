using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class ContatoFuncionario
{
    [Column(TypeName ="varchar(40)")]
    public string Celular { get; set; }
    public string CelularCorp { get; set; }
    public string Email { get; set; }
    public string EmailCorp { get; set; }
    public string FuncionarioId { get; set; }
    public DateTime DataUltimaAtualizacao { get; set; }
    [JsonIgnore]
    public Funcionario Funcionario { get; set; }
}
