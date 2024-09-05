namespace miLibreriaDeClases
{
    public interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(ListaDobleEnlazada listA, ListaDobleEnlazada listB, SortDirection direction);
    }
}