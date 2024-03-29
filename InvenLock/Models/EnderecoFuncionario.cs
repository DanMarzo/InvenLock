using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class EnderecoFuncionario
{
    public int FuncionarioId { get; set; }
    [JsonIgnore]
    public Funcionario Funcionario { get; set; }
    public string FuncionarioCEP { get; set; }
    public int Numero { get; set; }
    public string NomeRua { get; set; }
    public string Complemento { get; set; }
    public DateTime? DataUltimaAtualizacao { get; set; }    
}
