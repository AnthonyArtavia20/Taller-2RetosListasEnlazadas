namespace miLibreriaDeClases
{
    public interface IList
    {
        //Esta es una interfaz encargada de señalar cuales métodos debería de implementar cada lista.
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(ListaDobleEnlazada listB, SortDirection direction);
    }
}