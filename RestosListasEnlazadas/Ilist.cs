public interface Ilist
{
    void InsertInOrder(int value)
    int DeleteFirst();
    int DeleteLast();
    bool DeleteValue(int value);
    int GetMiddle();
    void MergeSorted(IList listA, IList listB, SortDirection direction);
}