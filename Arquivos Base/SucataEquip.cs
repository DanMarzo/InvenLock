using System.Text.Json.Serialization;

namespace InvenLock.Models;

public class SucataEquip
{
    public int SucataEquipId { get; set; }
    public DateTime DataDescarte { get; set; }
    public string DescMotivo { get; set; }
    public int ConsertoEquipId { get; set; }
    [JsonIgnore]
    public ConsertoEquip ConsertoEquip { get; set; }
}
