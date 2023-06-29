using System;
using System.Collections;


class Program
{
    public static void Main(string[] args)
    {
        Jogadores[] time = new Jogadores[30];
        ArrayList Lista = new ArrayList(20);
        int n = 0;
        string linha = Console.ReadLine();
        while (linha != "FIM")
        {
            time[n] = new Jogadores();
            time[n].Leitura(linha);
            Lista.Add(time[n]);
            n++;
            linha = Console.ReadLine();
        }
        int pos;
        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string linha2 = Console.ReadLine();
            string[] Formatada = linha2.Split(' ');

            if (Formatada[0] == "II")
            {
                time[n] = new Jogadores();
                time[n].Leitura(linha2);
                Lista.Insert(0, time[n]);
            }
            else if (Formatada[0] == "I*")
            {
                pos= int.Parse(Formatada[1]);
                time[n] = new Jogadores();
                time[n].Leitura(linha2);
                Lista.Insert(pos, time[n]);
            }
            else if (Formatada[0] == "R*")
            {
                pos=int.Parse(Formatada[1]);
                Lista.RemoveAt(pos);
            }
            else if (Formatada[0] == "IF")
            {
                time[n] = new Jogadores();
                time[n].Leitura(linha2);
                Lista.Add(time[n]);
            }
            else if (Formatada[0] == "RF")
            {
                Lista.RemoveAt(Lista.Count-1);
            }
            else if (Formatada[0] == "RI")
            {
                Lista.RemoveAt(0);
            }
        }

        foreach (Jogadores item in Lista)
        {
            item.Imprimir();
        }
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

    public static int GetTamanho(string Nome)
    {
        int Total = 0;
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