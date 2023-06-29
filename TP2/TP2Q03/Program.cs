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
            if(PesqBin(time,pesquisa,n)){
                Console.WriteLine("SIM");
            }else{
                Console.WriteLine("NAO");
            }
            pesquisa = Console.ReadLine();
        }

    }

     public static bool PesqBin(Jogadores[] time, string nome, int n)
    {
        int inicio = 0;
        int fim = n - 1;

        while (inicio <= fim)
        {
            int meio = (inicio + fim) / 2;

            if (time[meio].GetNome().CompareTo(nome) == 0)
            {
                return true;
            }
            else if (time[meio].GetNome().CompareTo(nome) > 0)
            {
                fim = meio - 1;
            }
            else
            {
                inicio = meio + 1;
            }
        }

        return false;
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

    public static int GetTamanho(string Nome){
        int Total =0;
        for (int i = 0; i < Nome.Length; i++)
        {
            Total += Convert.ToInt32(Nome[i]);
        }
        return Total;
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