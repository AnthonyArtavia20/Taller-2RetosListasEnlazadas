using miLibreriaDeClases;

public class Program
{
    public static void Main(string[] args)
    {
        ListaDobleEnlazada lista1 = new ListaDobleEnlazada();
        ListaDobleEnlazada lista2 = new ListaDobleEnlazada();

        //Console.WriteLine("Lista Antes de invertir: ");
        //lista1.InsertInOrder(2);
        //lista1.InsertInOrder(3);
        //lista1.InsertInOrder(4);
        //lista1.InsertInOrder(5);
        //lista1.InsertInOrder(1);

        //lista1.ImprimirLista();

        //Console.WriteLine("Lista después de invertir: ");

        //lista1.InvertirLista();
        //lista1.ImprimirLista();

        //lista1.GetMiddle();

        lista1.InsertInOrder(5);
        lista1.InsertInOrder(6);
        lista1.InsertInOrder(7);
        lista1.InsertInOrder(8);
        
        lista2.InsertInOrder(1);
        lista2.InsertInOrder(2);
        lista2.InsertInOrder(3);

        lista1.MergeSorted(lista1,lista2,SortDirection.Ascendente);

        lista1.ImprimirLista();
        lista1.GetMiddle();
    }
}