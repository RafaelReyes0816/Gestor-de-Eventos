using Tarea03.Models;
using Tarea03.Estructuras;
using System.Collections.Generic;

namespace Tarea03.Servicios
{
    //Esta clase gestiona la lógica de la agenda de eventos utilizando una lista enlazada genérica.
    public class GestorEventos
    {
        private ListaEnlazada<Evento> lista;

        public GestorEventos()
        {
            lista = new ListaEnlazada<Evento>();
        }

        public void AgregarEvento(int id, string nombre, DateTime fecha, string lugar, string descripcion)
        {
            Evento evento = new Evento(id, nombre, fecha, lugar, descripcion);
            lista.Agregar(evento);
        }

        public bool EliminarEvento(int id)
        {
            return lista.Eliminar(e => e.Id == id);
        }

        public Evento BuscarEvento(int id)
        {
            return lista.Buscar(e => e.Id == id);
        }

        public List<Evento> ObtenerTodos()
        {
            return lista.ObtenerTodos();
        }

        public bool MarcarComoRealizado(int id)
        {
            Evento evento = BuscarEvento(id);
            if (evento != null && !evento.Realizado)
            {
                evento.Realizado = true;
                return true;
            }
            return false;
        }

        public List<Evento> ObtenerPendientes()
        {
            List<Evento> pendientes = new List<Evento>();
            foreach (Evento e in ObtenerTodos())
            {
                if (!e.Realizado)
                    pendientes.Add(e);
            }
            return pendientes;
        }

        public List<Evento> ObtenerRealizados()
        {
            List<Evento> realizados = new List<Evento>();
            foreach (Evento e in ObtenerTodos())
            {
                if (e.Realizado)
                    realizados.Add(e);
            }
            return realizados;
        }
    }
}