using System;


class Program
{
    public static void Main(string[] args)
    {
        Jogadores[] time = new Jogadores[30];
        int n = 0;
        string linha = Console.ReadLine();
        while (linha != "FIM")
        {
            time[n] = new Jogadores();
            time[n].Leitura(linha);
            n++;
            linha = Console.ReadLine();
        }
        string pesquisa = Console.ReadLine();
        while (pesquisa != "FIM")
        {
            if(PesquisaSeq(pesquisa, time,n)){
                Console.WriteLine("SIM");
            }else{
                Console.WriteLine("NAO");
            }
            pesquisa = Console.ReadLine();
        }

    }

    static bool PesquisaSeq(string pesquisa, Jogadores[] time, int qnt)
    {
        bool confere = false;
        for (int i = 0; i < qnt; i++)
        {
            if (time[i].GetNome() == pesquisa)
            {
                confere = true;
            }
        }
        return confere;
    }
}

class Jogadores
{
    string Nome;
    string Foto;
    int Id;
    string Nascimento;
    int[] Times;

    public string GetNome()
    {
        return Nome;
    }

    public void Leitura(string linha)
    {
        string remove = linha.Replace("[", "");
        string remove1 = remove.Replace("]", "");
        string remove2 = remove1.Replace('"', '@');
        string remove3 = remove2.Replace("@", "");
        linha = remove3;
        int contador = 6;
        string[] Formatada = linha.Split(',');
        Nome = Formatada[1];
        Id = int.Parse(Formatada[5]);
        Foto = Formatada[2];
        Nascimento = Formatada[3];
        if (Formatada.Length <= 7)
        {
            Times = new int[1];
            Times[0] = int.Parse(Formatada[6]);
        }
        else
        {
            Times = new int[Formatada.Length - 6];
            for (int i = 0; i < Times.Length; i++)
            {
                Times[i] = int.Parse(Formatada[contador]);
                contador++;
            }
        }
    }
    public void Imprimir()
    {
        Console.Write(Id + " " + Nome + " " + Nascimento + " " + Foto + " " + "(");
        for (int i = 0; i < Times.Length; i++)
        {
            if (i == Times.Length - 1)
            {
                Console.Write(Times[i]);
                break;
            }
            else
            {
                Console.Write(Times[i] + ", ");
            }
        }
        Console.Write(")");
        Console.WriteLine("");
    }
}