using InvenLock.Models.Enums.Conserto;
using InvenLock.Models.Enums.Equipamento;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class ConsertoEquip
{
    [JsonIgnore]
    public int ConsertoEquipId { get; set; }
    public SituacaoConserto? SituacaoConserto { get; set; }
    public string Procedimentos { get; set; }
    public string OcorrenciaId { get; set; }
    [JsonIgnore]
    public Ocorrencia Ocorrencia { get; set; }
    public int CodigoInterno { get; set; }
    [Column(TypeName = "varchar(70)")]
    public string EquipamentoId { get; set; }
    [JsonIgnore]
    public Equipamento Equipamento { get; set; }
    [JsonIgnore]
    public SucataEquip SucataEquip { get; set; }
}
