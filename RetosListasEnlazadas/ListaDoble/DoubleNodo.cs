//Creación de la clase para la creación de nodos de la lista doblemente
//enlazada

namespace RetosListasEnlazadas
{
    public class DoubleLinkedListNodo
    {
        public DoubleLinkedListNodo? siguiente {get; set;}
        public DoubleLinkedListNodo? Anterior {get; set;}
        public int valor {get; set;} //El valor que contiene el Nodo-

        public DoubleLinkedListNodo(int valor)
        {
            this.valor = valor;
            this.siguiente = null;
            this.Anterior = null;
        }
    }
}