using Tarea03.Models;

namespace Tarea03.Estructuras
{
    //Lista enlazada simple para almacenar objetos Evento.
    public class Nodo
    {
        public Evento Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Evento dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class ListaEnlazada
    {
        private Nodo cabeza;

        public ListaEnlazada()
        {
            cabeza = null;
        }

        public void Agregar(Evento evento)
        {
            Nodo nuevo = new Nodo(evento);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public bool Eliminar(int id)
        {
            Nodo actual = cabeza;
            Nodo anterior = null;

            while (actual != null)
            {
                if (actual.Dato.Id == id)
                {
                    if (anterior == null)
                    {
                        cabeza = actual.Siguiente;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }
                    return true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
            return false;
        }

        public Evento Buscar(int id)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.Id == id)
                {
                    return actual.Dato;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public List<Evento> ObtenerTodos()
        {
            List<Evento> eventos = new List<Evento>();
            Nodo actual = cabeza;
            while (actual != null)
            {
                eventos.Add(actual.Dato);
                actual = actual.Siguiente;
            }
            return eventos;
        }
    }
}