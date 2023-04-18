
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using InvenLock.Models.Enums.Funcionario;

namespace InvenLock.Models;

public class Funcionario
{
    public int FuncionarioId { get; set; }   
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string CPF { get; set; }
    public int NumOcorrencias { get; set; }
    public DateTime? Admissao { get; set; }
    public DateTime? Demissao { get; set; }
    public bool? Status { get; set; }
    [NotMapped]
    public string PwdString { get; set; }
    public byte[] Pwdhash { get; set; }
    public byte[] Pwdsalt { get; set; }

    public FuncionarioCargo FuncionarioCargo { get; set; }
    public ICollection<Ocorrencia> Ocorrencia { get; set; }
    public ContatoFuncionario ContatoFuncionario { get; set; }
    public EnderecoFuncionario EnderecoFuncionario { get; set; }
    public ICollection<EquipamentoEmprestimo> EquipamentoEmprestimos { get; set; }
}
