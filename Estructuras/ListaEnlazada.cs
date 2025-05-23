using System.Collections.Generic;
using Tarea03.Models;

namespace Tarea03.Estructuras
{
    // Lista enlazada simple genérica para almacenar cualquier tipo de objeto.
    public class Nodo<T>
    {
        public T Dato { get; set; }
        public Nodo<T> Siguiente { get; set; }

        public Nodo(T dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class ListaEnlazada<T>
    {
        private Nodo<T> cabeza;

        public ListaEnlazada()
        {
            cabeza = null;
        }

        public void Agregar(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo<T> actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public bool Eliminar(Predicate<T> condicion)
        {
            Nodo<T> actual = cabeza;
            Nodo<T> anterior = null;

            while (actual != null)
            {
                if (condicion(actual.Dato))
                {
                    if (anterior == null)
                        cabeza = actual.Siguiente;
                    else
                        anterior.Siguiente = actual.Siguiente;
                    return true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
            return false;
        }

        public T Buscar(Predicate<T> condicion)
        {
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                if (condicion(actual.Dato))
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return default(T);
        }

        public List<T> ObtenerTodos()
        {
            List<T> lista = new List<T>();
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                lista.Add(actual.Dato);
                actual = actual.Siguiente;
            }
            return lista;
        }
    }
}