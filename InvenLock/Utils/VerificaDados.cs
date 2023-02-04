namespace InvenLock.Utils;

public class VerificaDados
{
    private string CPF { get; set; }
    public bool RecebeCpf(string cpfString)
    {
        cpfString = cpfString.Replace(".","").Replace("-","");
        
        int[] multiDigitoUm = new int[9]{10,9,8,7,6,5,4,3,2}; //Nove digitos vamos para o FOR
        int[] multiDigitoDois = new int[10]{11,10,9,8,7,6,5,4,3,2}; //10 digitos vamos para o FOR
        string digitos;
        int[] verificadores = new int[2];

        if(cpfString.Length == 11)
            digitos = cpfString.Substring(9,2);
        else 
            return false;

        cpfString = cpfString.Remove(cpfString.Length - 2);//remove os dois ultimos digitos

        for (int i = 0; i < multiDigitoUm.Length ; i++)
        {
            verificadores[0]  +=  multiDigitoUm[i] * int.Parse(cpfString[i].ToString());
        }
        verificadores[0] = verificadores[0] % 11;
        if(verificadores[0] < 2)
            verificadores[0] = 0;
        else
            verificadores[0] = 11 - verificadores[0];
        
        cpfString += verificadores[0].ToString();//Vamos adicionar no mais um digito o que obtivemos agora   
        for (int i = 0; i < multiDigitoDois.Length; i++)
        {
            verificadores[1] += multiDigitoDois[i] * int.Parse(cpfString[i].ToString());
        }
        verificadores[1] = verificadores[1] % 11;
        if(verificadores[1] < 2)
            verificadores[1] = 0;
        else
            verificadores[1] = 11 - verificadores[1];

        string digitoVerificadores = $"{verificadores[0]}{verificadores[1]}";
        if(int.Parse(digitos) == int.Parse(digitoVerificadores))
            return true;
        else
            return false;

    }
    public string ConsertaCpf(string cpfString)
    {
        return cpfString.Replace(".", "").Replace("-", "");
    }
}
