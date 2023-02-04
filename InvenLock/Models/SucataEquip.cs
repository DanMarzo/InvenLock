
using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class SucataEquip
{
    [JsonIgnore]
    public int SucataEquipId { get; set; }
    public DateTime DataDescarte { get; set; }
    public string MotivoSucata { get; set; }
    public int CodigoInterno { get; set; }
    public int ConsertoEquipId { get; set; }
    [JsonIgnore]
    public ConsertoEquip ConsertoEquip { get; set; }
}
