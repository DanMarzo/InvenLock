using System.ComponentModel.DataAnnotations.Schema;

namespace InvenLock.Models;

public class ContatoFuncionario
{
    [Column(TypeName ="varchar(40)")]
    public string FuncionarioId { get; set; }
    public string Celular { get; set; }
    public string CelularCorp { get; set; }
    public string Email { get; set; }
    public string EmailCorp { get; set; }
}
