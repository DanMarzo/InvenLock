using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using InvenLock.Models.Enums.Equipamento;

namespace InvenLock.Models;

public class Equipamento
{
    [JsonIgnore]
    [Column(TypeName = "varchar(70)")]
    public string EquipamentoId { get; set; }
    public DateTime? DataEntrega { get; set; }
    [JsonIgnore]
    public int CodigoInterno { get; set; }
    public SituacaoEquip SituacaoEquip { get; set; }
    public TipoEquip TipoEquip { get; set; }
    [Column(TypeName = "varchar(70)")]
    public string FuncionarioRecebedor { get; set; }
    public string MarcaEquipamento { get; set; }
    public string DescEquipamento { get; set; }
    
    [JsonIgnore]
    public ICollection<ConsertoEquip> ConsertoEquips { get; set; }
    [JsonIgnore]
    public ICollection<EquipamentoEmprestimo> EquipamentoEmprestimo { get; set; }
}
