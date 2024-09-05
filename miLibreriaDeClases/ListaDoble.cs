

namespace miLibreriaDeClases
{
    public class ListaDobleEnlazada : IList
    {
        private DoubleLinkedListNodo? head {set;get;} //Primer elemento
        private DoubleLinkedListNodo? ultimo {set;get;} // tail
        private  int contador; //Para llevar la cuenta de cuantos elementos  hay en la linkedList.
        
        public ListaDobleEnlazada() //Inicializamos las referencias a null.
        {
            head = null;
            ultimo = null;
        }

        public void InsertInOrder(int value)
        {
            DoubleLinkedListNodo nuevoNodoACrear = new DoubleLinkedListNodo(value);

            if (head == null)
            {
                head = ultimo = nuevoNodoACrear; //La cabeza al ser null, quiere decir que no hay elemento en la lista
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

            contador++; // Aumentar el contador de elementos
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
            
            if (nodoActual.siguiente == null) return -1; // para evitar el mensaje de null exeption.

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
                if (NodoActual.Anterior == null || NodoActual.siguiente == null) return false; //Para evitar referencias null.

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

            // Si el contador es par, se ajusta para redondear hacia arriba
            int IndiceMedio = (contador + 1) / 2;

            DoubleLinkedListNodo? NodoActual = head;
            
            for (int i = 1; i < IndiceMedio; i++) // Menos 1 para poder 
            {
                if (NodoActual == null)return -1; //Para evitar null exeption
                NodoActual = NodoActual.siguiente;
            }
            if (NodoActual == null)return -1; //Para evitar null exeption
            Console.WriteLine("El centro de la lista es: ");
            Console.WriteLine(NodoActual.valor);
            return NodoActual.valor;
        }

        public void MergeSorted(ListaDobleEnlazada listA, ListaDobleEnlazada listB, SortDirection direction)
        {
            //Mezclar lista B en lista A

            //Comprobamos que ambas listas existan
            if (listA == null)
            {
                throw new ArgumentNullException("La lista1 es nula, no se puede mezclar");
            }

            if (listB == null)
            {
                throw new ArgumentNullException("La lista2 es nula, no se puede mezclar");
            }

            //Sacamos las referencias de las cabezas de ambas listas, esto con el fin de poder avanzar hasta el final de cada una.
            DoubleLinkedListNodo? nodoActualListaA = listA.head;
            DoubleLinkedListNodo? nodoActualListaB = listB.head;

            //Creamos una lista temporal para poder ir agregando los elementos ordenanos(Se hace así para tener más versatilidad a la hora de hacer ascendente o descendente)
            ListaDobleEnlazada? listaTemporal = new ListaDobleEnlazada();

            //Hacemos un ciclo while que constantemente recorra ambas listas pero que por separado verifique y separe los elementos
            while (nodoActualListaA != null & nodoActualListaB != null)
            {
                if (nodoActualListaA == null || nodoActualListaB == null) return; // Para evitar un error de null.

                if(nodoActualListaA.valor <= nodoActualListaB.valor)
                {
                    listaTemporal.InsertInOrder(nodoActualListaA.valor);
                    nodoActualListaA = nodoActualListaA.siguiente;
                }
                else
                {
                    listaTemporal.InsertInOrder(nodoActualListaB.valor);
                    nodoActualListaB = nodoActualListaB.siguiente;
                }
            }

            if (direction == SortDirection.Descendente) // En caso de que se quiera descendente, luego de que se ordena, se invierte.
            {  
                listaTemporal.InvertirLista();
            }

            //En caso de que una de las listas sea más larga que la otra, es decir el proceso termine antes, entonces agregamos el resto de elementos restantes.
            while (nodoActualListaA != null)
            {
                listaTemporal.InsertInOrder(nodoActualListaA.valor);
                nodoActualListaA = nodoActualListaA.siguiente;
            }
            while (nodoActualListaB != null)
            {
                listaTemporal.InsertInOrder(nodoActualListaB.valor);
                nodoActualListaB = nodoActualListaB.siguiente;
            }

            listA.head = null; //Limpiamos la lista A antes de pasarle todos los elementos ya mezclados y ordenados.
            DoubleLinkedListNodo? nodoActualDeLaListaTemporal = listaTemporal.head;

            while (nodoActualDeLaListaTemporal != null)
            {
                listA.InsertInOrder(nodoActualDeLaListaTemporal.valor);
                nodoActualDeLaListaTemporal = nodoActualDeLaListaTemporal.siguiente;
            }

            //reasignamos las referencias para la lista 1
            listA.head = listaTemporal.head;
            listA.ultimo = listaTemporal.ultimo;
            listA.contador = listaTemporal.contador;
        }

        public void ImprimirLista()
        {
            DoubleLinkedListNodo? ActualAImprimir = head;

            while (ActualAImprimir != null)
            {
                Console.WriteLine(ActualAImprimir.valor);
                ActualAImprimir = ActualAImprimir.siguiente;
            }
        }

        public void InvertirLista()
        {
            DoubleLinkedListNodo? actual = head; // creamos un nodo que almacene la referencia de head para no alterarla.
            DoubleLinkedListNodo? temporal = null; //creamos un nodo temporal que va a servir para poder almacenar referencias.

            while (actual != null) //Mantenemos este ciclo hasta llegar a null, cuando se llegue a null -> "ver el intecambio de head y último"
            {
                temporal = actual.siguiente; //Se guarda la referencia al siguiente nodo, es decir, se designa el siguiente como temporal.
                actual.siguiente = actual.Anterior; //"Invetirmos la referencia del siguiente (de siguiente a anterior).
                actual.Anterior = temporal;//Y luego invertirmos la referencia del anterior (de anterior a siguiente).
                actual = temporal; //Posterior decimos que el actual va a ser el anterior, es decir, el elemento siguiente del nodo "actual" original.
            }

            //Intercambio de head y último por medio de la variable temporal(la cual queda como última en la lista al haber llegado hasta el final)
            temporal = head; //guardamos la referencia original de head, esto con el proposito de luego decir que esta head va a ser el último.
            head = ultimo; // decimos que la cabeza va a ser "último" osea la invertimos
            ultimo = temporal; // y el último es el antiguio primer nodo.

            //Es decir, intercambiamos head por último y último por head, todo mediante una variable temporal para no perder la referencia original de gente yluego igualarla.
        }
    }
}