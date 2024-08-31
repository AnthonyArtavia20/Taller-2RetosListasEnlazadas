using System.Transactions;

namespace RetosListasEnlazadas
{
    public class ListaDobleEnlazada : IList
    {
        private DoubleLinkedListNodo? head {set;get;} //Primer elemento
        private DoubleLinkedListNodo? ultimo {set;get;} // tail
        private DoubleLinkedListNodo? middle {set;get;} //Nodo central de la lista.
        public  int contador; //Para llevar la cuenta de cuantos elementos  hay en la linkedList.
        
        public ListaDobleEnlazada() //Inicializamos las referencias a null.
        {
            head = null;
            ultimo = null;
            middle = null;
        }

        public void InsertInOrder(int value)
        {
            DoubleLinkedListNodo nuevoNodoACrear = new DoubleLinkedListNodo(value);

            if (head == null)
            {
                head = ultimo = middle = nuevoNodoACrear; //La cabeza al ser null, quiere decir que no hay elemento en la lista
                //lo que hace que el nuevo noodo sea tanto el primero, como el último, como el central, entonces el nuevo nodo será todo eso.
                
            }
            else
            {
                DoubleLinkedListNodo? NodoActual = head;
                while (NodoActual != null && NodoActual.valor < value)
                {
                    NodoActual = NodoActual.siguiente;
                }

                if (NodoActual == null && ultimo != null) //Se recorrió toda la lista. entonces insertamos al final.
                {
                    ultimo.siguiente = nuevoNodoACrear;
                    nuevoNodoACrear.Anterior = ultimo;
                    ultimo = nuevoNodoACrear;
                }
                else if (NodoActual.Anterior == null) //En el caso de que se tenga que insetar al frente
                {
                    nuevoNodoACrear.siguiente = head;
                    head.Anterior = nuevoNodoACrear;
                    head = nuevoNodoACrear;
                }
                else //Si se tiene que insertar por el medio y no en los extremos.
                {
                    nuevoNodoACrear.Anterior = NodoActual.Anterior; //Referencia anterior del nodo a crear va a ser el nodo anterior que tiene el nodo actual.
                    nuevoNodoACrear.siguiente = NodoActual; //Igual para la parte del "siguiente" pero esta vez hacemos la referencia al nodo actual para poder "unirlo"
                    NodoActual.Anterior.siguiente = nuevoNodoACrear; //Al elemento anterior al Nodo Actual le actualizamos su referencia "siguiente" al nuevo elemento creado.
                    NodoActual.Anterior = nuevoNodoACrear; //Por último terminamos de enlazar la refrencia del anterior al nodo actual como el nuevo nodo creado.
                }
            }
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

            DoubleLinkedListNodo? nodoActual = head; //Almacenamos temporalmente el valor de la cabeza
            //de lo contrario si iteraramos en la referencia actual, la referencia se movería,
            //moviendo el resto de referencias también.
            while (nodoActual.siguiente != null && nodoActual.siguiente.siguiente != null) //Iteramos con una copia de la referencia de head
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
            DoubleLinkedListNodo? NodoActual = head;

            //Buscar el valor por medio de el ciclo hasta encontrarlo.
            while (NodoActual != null && NodoActual.valor != value)
            {
                NodoActual = NodoActual.siguiente;
            }

            if (NodoActual == null) //Si se recorrió toda la lista.
            {
                return false; // No se encontró el valor
            }

            //Si el nodo es head:
            if (NodoActual == head)
            {
                head = NodoActual.siguiente;
                if (head != null)
                {
                    head.Anterior = null;
                }
                else
                {
                    ultimo = null; //Si head es null, también lo será el úlitmo.
                }
            }
            else if (NodoActual == ultimo) //Si el nodo estuviera de último
            {
                ultimo = NodoActual.Anterior;
                if (ultimo != null)
                {
                    ultimo.siguiente = null;
                }
            }
            else //Si no es ningún nodo externo, entonces nos "saltamos" el nodo actual.
            {
                NodoActual.Anterior.siguiente = NodoActual.siguiente;
                NodoActual.siguiente.Anterior = NodoActual.Anterior;
            }

            contador--;
            return true;
        }

        public int GetMiddle()
        {
            if (head == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }
            int IndiceMedio = (contador - 1) /2;
            DoubleLinkedListNodo? NodoActual = head;
            
            for (int i = 0; i < IndiceMedio; i++)
            {
                if (NodoActual == null)return -1; //Para evitar null exeption
                NodoActual = NodoActual.siguiente;
            }
            if (NodoActual == null)return -1; //Para evitar null exeption
            return NodoActual.valor;
        }

        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
            //Implementación futura
        }

        public void ImprimirLista()
        {
            DoubleLinkedListNodo? ActualAImprimir = head;

            while (ActualAImprimir != null)
            {
                Console.WriteLine(ActualAImprimir);
                ActualAImprimir = ActualAImprimir.siguiente;
            }
        }
    }
}