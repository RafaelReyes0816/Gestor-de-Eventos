using System.Collections.Generic;

namespace Tarea03.Estructuras
{
    // Nodo para lista doblemente enlazada
    public class NodoDoble<T>
    {
        public T Dato { get; set; }
        public NodoDoble<T> Siguiente { get; set; }
        public NodoDoble<T> Anterior { get; set; }

        public NodoDoble(T dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }
    }

    // Lista doblemente enlazada genérica
    public class ListaDobleEnlazada<T>
    {
        private NodoDoble<T> cabeza;
        private NodoDoble<T> cola;

        public ListaDobleEnlazada()
        {
            cabeza = null;
            cola = null;
        }

        public void Agregar(T dato)
        {
            NodoDoble<T> nuevo = new NodoDoble<T>(dato);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
        }

        public List<T> ObtenerTodos()
        {
            List<T> lista = new List<T>();
            NodoDoble<T> actual = cabeza;
            while (actual != null)
            {
                lista.Add(actual.Dato);
                actual = actual.Siguiente;
            }
            return lista;
        }
    }
}