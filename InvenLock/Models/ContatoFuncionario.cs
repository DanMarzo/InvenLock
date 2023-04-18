using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class ContatoFuncionario
{
    public int FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    public DateTime? UltimaAtualizacao { get; set; }
    public string Celular { get; set; }
    public string CelularCorp { get; set; }
    public string Email { get; set; }
    public string EmailCorp { get; set; }
}
