using System;


class Program
{
    public static void Main(string[] args)
    {
        Jogadores[] time = new Jogadores[30];
        Lista list = new Lista(20);
        int n = 0;
        string linha = Console.ReadLine();
        while (linha != "FIM")
        {
            time[n] = new Jogadores();
            time[n].Leitura(linha);
            list.inserirFim(time[n]);
            n++;
            linha = Console.ReadLine();
        }
        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string linha2 = Console.ReadLine();
            string[] Formatada = linha2.Split(' ');
            if (Formatada[0] == "II")
            {
                time[n] = new Jogadores();
                time[n].Leitura(linha2);
                list.inserirInicio(time[n]);
            }
            else if (Formatada[0] == "I*")
            {
                time[n] = new Jogadores();
                time[n].Leitura(linha2);
                int posição = int.Parse(Formatada[1]);
                list.inserir(time[n], posição);
            }
            else if (Formatada[0] == "R*")
            {
                int posição = int.Parse(Formatada[1]);
                list.remover(posição);
            }
            else if(Formatada[0]=="IF"){
                time[n] = new Jogadores();
                time[n].Leitura(linha2);
                list.inserirFim(time[n]);
            }
            else if(Formatada[0]=="RF"){
                list.removerFim();
            }
            else if(Formatada[0]=="RI"){
                list.removerInicio();
            }
        }
        list.ImprimiList();
    }
}
class Lista
{
    private Jogadores[] array;
    private int n;

    public Lista(int tamanho)
    {
        array = new Jogadores[tamanho];
        n = 0;
    }

    public void inserirInicio(Jogadores x)
    {

        //validar insercao
        if (n >= array.Length)
        {
            throw new Exception("Erro ao inserir!");
        }

        //levar elementos para o fim do array
        for (int i = n; i > 0; i--)
        {
            array[i] = array[i - 1];
        }

        array[0] = x;
        n++;
    }
    public void inserirFim(Jogadores x)
    {

        //validar insercao
        if (n >= array.Length)
        {
            throw new Exception("Erro ao inserir!");
        }

        array[n] = x;
        n++;
    }

    public void inserir(Jogadores x, int pos)
    {

        //validar insercao
        if (n >= array.Length || pos < 0 || pos > n)
        {
            throw new Exception("Erro ao inserir!");
        }

        //levar elementos para o fim do array
        for (int i = n; i > pos; i--)
        {
            array[i] = array[i - 1];
        }

        array[pos] = x;
        n++;
    }

    public Jogadores removerInicio()
    {

        //validar remocao
        if (n == 0)
        {
            throw new Exception("Erro ao remover!");
        }

        Jogadores resp = array[0];
        n--;

        for (int i = 0; i < n; i++)
        {
            array[i] = array[i + 1];
        }

        return resp;
    }

    public Jogadores removerFim()
    {

        //validar remocao
        if (n == 0)
        {
            throw new Exception("Erro ao remover!");
        }

        return array[--n];
    }

    public Jogadores remover(int pos)
    {

        //validar remocao
        if (n == 0 || pos < 0 || pos >= n)
        {
            throw new Exception("Erro ao remover!");
        }

        Jogadores resp = array[pos];
        n--;

        for (int i = pos; i < n; i++)
        {
            array[i] = array[i + 1];
        }

        return resp;
    }

    public void mostrar()
    {
        Console.Write("[ ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("]");
    }

    public bool pesquisar(Jogadores x)
    {
        bool retorno = false;
        for (int i = 0; i < n && retorno == false; i++)
        {
            retorno = (array[i] == x);
        }
        return retorno;
    }
    public void ImprimiList(){
        for (int i = 0; i < n; i++)
        {
          array[i].Imprimir();
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