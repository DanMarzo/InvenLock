using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class ContatoFuncionario
{
    [Column(TypeName ="varchar(70)")]
    public string FuncionarioId { get; set; }
    [JsonIgnore]
    public Funcionario Funcionario { get; set; }
    public DateTime? DataUltimaAtualizacao { get; set; }
    public string Celular { get; set; }
    public string CelularCorp { get; set; }
    public string Email { get; set; }
    public string EmailCorp { get; set; }
}
