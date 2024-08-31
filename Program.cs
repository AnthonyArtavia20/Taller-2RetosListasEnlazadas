using RetosListasEnlazadas;

public class Program
{
    public static void Main(string[] args)
    {
        ListaDobleEnlazada lista1 = new ListaDobleEnlazada();

        Console.WriteLine("Lista Antes de imprimir: ");
        lista1.InsertInOrder(2);
        lista1.InsertInOrder(3);
        lista1.InsertInOrder(4);
        lista1.InsertInOrder(5);
        lista1.InsertInOrder(1);

        lista1.ImprimirLista();

        //Console.WriteLine("Lista después de imprimir: ");
//
        //lista1.InvertirLista();
        //lista1.ImprimirLista();

        lista1.GetMiddle();
    }
}