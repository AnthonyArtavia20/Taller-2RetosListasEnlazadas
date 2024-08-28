namespace RetosListasEnlazadas
{
    public class ListaDobleEnlazada : IList
    {
        private DoubleLinkedListNodo? head; //Primer elemento
        private DoubleLinkedListNodo? ultimo; // tail
        public  int contador; //Para llevar la cuenta de cuantos elementos  hay en la linkedList.
        
        public ListaDobleEnlazada()
        {
            
        }
        public void InsertInOrder(int value)
        {
            //Implementación futura
        }

        public int DeleteFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            } 

            int valorNodoEliminado = head.valor; //Almacenamos el valor del nodo a eliminar.
            head = head.siguiente; // Head pasa a ser el siguiente elemento en la lista.

            if (head != null) //Si la cabeza no está vacía quiere decir que tiene algo
            {
                head.Anterior = null;  //Hay que eliminar la referencia, pues el nuevo head no puede
                //tener nodo anterior.
            }
            else    //Si la nueva cabeza es nula, entonces quiere decir que el último tambíen es null
            {
                ultimo = null;
            }

            contador--; //Decrecemos la cantidad de elemetos en el contador.
            return valorNodoEliminado; //Retornamos el valor del nodo eliminado.
        }

        public int DeleteLast()
        {
            //Implementación futura
            return 0; // Placeholder
        }

        public bool DeleteValue(int value)
        {
            //Implementación futura
            return false; // Placeholder
        }

        public int GetMiddle()
        {
            //Implementación futura
            return 0; // Placeholder
        }

        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
            //Implementación futura
        }
    }
}