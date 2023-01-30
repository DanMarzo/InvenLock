using InvenLock.Models.Enums.Equipamento;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class Equipamento
{
    [Column(TypeName = "varchar(40)")]
    public string EquipamentoId { get; set; }
    public DateTime DataEntrega { get; set; }
    public SituacaoEquip SituacaoEquip { get; set; }
    public TipoEquip TipoEquip { get; set; }
    public string DescEquipamento { get; set; }
    [JsonIgnore]
    public ICollection<ConsertoEquip> ConsertoEquips { get; set; }

    [Column(TypeName ="varchar(40)")]
    public string FuncionarioId { get; set; }
    [JsonIgnore]
    public Funcionario Funcionario { get; set; }
}
