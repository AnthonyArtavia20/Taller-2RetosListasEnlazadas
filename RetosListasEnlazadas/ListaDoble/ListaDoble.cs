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
            if (head == null)
            {
                throw new InvalidOperationException("La lista está vacía"); //Pues si no tiene cabeza, menos cuerpo.
            }

            if (head.siguiente == null) //Significa que el siguiente puede ser null
            {
                int valorNodoEliminado = head.valor; //Almacenamos el valor del número que tiene el nodo.
                head = null; //Cabeza actual va a ser nulo
                ultimo = null; //Referencia a último va a ser nulo.
                contador--; //Decrementamos la cantidad de elementos en la lista según el contador.
                return valorNodoEliminado;
            }

            DoubleLinkedListNodo nodoActual = head; //Almacenamos temporalmente el valor de la cabeza
            //de lo contrario si iteraramos en la referencia actual, la referencia se movería,
            //moviendo el resto de referencias también.
            while (head.siguiente.siguiente != null) //Iteramos con una copia de la referencia de head
            {
                nodoActual = nodoActual.siguiente;
            }

            int valorNodoEliminadoUltimo = nodoActual.siguiente.valor; //Almacenamos el valor del nodo a eliminar.
            nodoActual.siguiente = null; //Eliminamos la referencia al último nodo.
            ultimo = nodoActual; //Entonces el nodo anterior que antes tenía un elemento después, ahora al no tener nada, ese nodo, pasa a ser le último.
            contador--; //Decrementamos el contador de elementos en la lista.

            return valorNodoEliminadoUltimo; //Devolvemos el valor del nodo que se eliminó.
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