using InvenLock.Models.Enums.Conserto;
using InvenLock.Models.Enums.Equipamento;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class ConsertoEquip
{
    public int ConsertoEquipId { get; set; }
    public SituacaoConserto SituacaoConserto { get; set; }
    public string DescProblema { get; set; }

    [Column(TypeName = "varchar(40)")]
    public string EquipamentoId { get; set; }
    [JsonIgnore]
    public Equipamento Equipamento { get; set; }
    [Column(TypeName = "varchar(40)")]
    public string OcorrenciaId { get; set; }
    [JsonIgnore]
    public Ocorrencia Ocorrencia { get; set; }
}
