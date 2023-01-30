using InvenLock.Data;
using InvenLock.Models;
using InvenLock.Models.Enums.EnumController;

namespace InvenLock.Utils;

public class ChavesPK
{
    public string PK { get; set; }
    private DataContext _context;
    public ChavesPK(DataContext context){ _context = context;}

    public ChavesPK()
    {
    }

    public string GeradorPK(int tipo)
    {
        bool aceito = false;
        switch(tipo)
        {
            case 1 :  
                inicioEquipamento:
                while(aceito != true)
                {
                    PK = Guid.NewGuid().ToString();
                    Equipamento chave = _context.Equipamentos.FirstOrDefault( x => x.EquipamentoId == PK);
                    if(chave is null) aceito = true;

                    else if(chave != null) aceito = false;
                }
                if(PK == "") goto inicioEquipamento;

                else return PK;
            case 2:
                inicioOcorrencia:
                while(aceito != true)
                {
                    PK = Guid.NewGuid().ToString();
                    Ocorrencia chave = _context.Ocorrencias.FirstOrDefault( x => x.OcorrenciaId == PK);
                    if(chave is null) aceito = true;

                    else if(chave != null) aceito = false;
                }
                if(PK == "") goto inicioOcorrencia;

                else return PK;
            case 3: 
                inicioFuncionario:
                while(aceito != true)
                {
                    PK = Guid.NewGuid().ToString();
                    Funcionario chave = _context.Funcionarios.FirstOrDefault( x => x.FuncionarioId == PK);
                    if(chave is null) aceito = true;

                    else if(chave != null) aceito = false;
                }
                if(PK == "") goto inicioFuncionario;

                else return PK;

                default:
                    return null;
        }
    }
}
