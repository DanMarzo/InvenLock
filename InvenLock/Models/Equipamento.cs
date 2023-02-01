using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using InvenLock.Models.Enums.Equipamento;

namespace InvenLock.Models;

public class Equipamento
{
    [Column(TypeName = "varchar(70)")]
    public string EquipamentoId { get; set; }
    public DateTime? DataEntrega { get; set; }
    public int CodigoInterno { get; set; }
    public SituacaoEquip SituacaoEquip { get; set; }
    public TipoEquip TipoEquip { get; set; }
    [Column(TypeName = "varchar(70)")]
    public string FuncionarioRecebedor { get; set; }
    public string MarcaEquipamento { get; set; }
    public string DescEquipamento { get; set; }
    [Column(TypeName = "varchar(70)")]
    public string FuncionarioId { get; set; }
    [JsonIgnore]
    public Funcionario Funcionario { get; set; }
    [JsonIgnore]
    public ICollection<ConsertoEquip> ConsertoEquips { get; set; }
}
