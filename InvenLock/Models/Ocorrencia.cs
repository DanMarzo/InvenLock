using InvenLock.Models.Enums.Conserto;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class Ocorrencia
{
    [Column(TypeName = "varchar(70)")]
    public string OcorrenciaId { get; set; }
    public string DescOcorrencia { get; set; }
    public int CodigoInterno { get; set; }
    public string FuncionarioId { get; set; }
    public string FuncionarioCPF { get; set; }
    public SituacaoConserto? SituacaoConserto { get; set; }
    public string MotivoSucata { get; set; }
    public DateTime? DataOcorrencia { get; set; }
    public DateTime? DataFimOcorrencia { get; set; }
    [JsonIgnore]
    public ConsertoEquip ConsertoEquip { get; set; }
}
