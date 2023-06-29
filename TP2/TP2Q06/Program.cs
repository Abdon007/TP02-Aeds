using System;


class Program
{
    public static void Main(string[] args)
    {
        Jogadores[] time = new Jogadores[30];
        Fila fila = new Fila(5);
        int n = 0;
        string linha = Console.ReadLine();
        while (linha != "FIM")
        {
            time[n] = new Jogadores();
            time[n].Leitura(linha);
            fila.inserir(time[n]);
            n++;
            linha = Console.ReadLine();
        }
        int tam = n;
        int num = int.Parse(Console.ReadLine());
        int contRemove = 1;
        for (int i = 0; i < num; i++)
        {
            string linha2 = Console.ReadLine();
            string[] Formatada = linha2.Split(' ');
            if(Formatada [0]=="R" && contRemove < 2){
                fila.remover();
                tam--;
                contRemove++;
            }
            else if(Formatada[0]=="I" && tam < 5){
                time[n] = new Jogadores();
                time[n].Leitura(linha2);
                fila.inserir(time[n]);
                tam++;
            }
            else if(Formatada[0]=="I" && tam == 5){
                fila.remover();
                tam--;
                time[n] = new Jogadores();
                time[n].Leitura(linha2);
                fila.inserir(time[n]);
                tam++;
            }
        }
        fila.ImprimiFila();
    }
}

class Fila {
   private Jogadores[] array;
   private int primeiro; // Remove do indice "primeiro".
   private int ultimo; // Insere no indice "ultimo".

   public Fila (int tamanho){
      array = new Jogadores[tamanho+1];
      primeiro = ultimo = 0;
   }

   public void inserir (Jogadores x){

      //validar insercao
      if (((ultimo + 1) % array.Length) == primeiro) {
         throw new InvalidOperationException("Erro");
      }

      array[ultimo] = x;
      ultimo = (ultimo + 1) % array.Length;
   }

   public Jogadores remover() {

      //validar remocao
      if (primeiro == ultimo) {
         throw new InvalidOperationException("Erro");
      }

      Jogadores resp = array[primeiro];
      primeiro = (primeiro + 1) % array.Length;
      return resp;
   }

   public void mostrar (){
      Console.Write("[ ");

      for(int i = primeiro; i != ultimo; i = ((i + 1) % array.Length)) {
         Console.Write(array[i] + " ");
      }

      Console.WriteLine("]");
   }

   public void mostrarRec(){
      Console.Write("[ ");
      mostrarRec(primeiro);
      Console.WriteLine("]");
   }

   public void mostrarRec(int i){
      if(i != ultimo){
         Console.Write(array[i] + " ");
         mostrarRec((i + 1) % array.Length);
      }
   }

   public bool isVazia() {
      return (primeiro == ultimo); 
   }

   public void ImprimiFila(){
        for(int i = primeiro; i != ultimo; i = ((i + 1) % array.Length)) {
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