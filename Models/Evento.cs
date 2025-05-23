namespace Tarea03.Models
{
    // Esta clase representa un evento con sus datos principales y su estado (realizado o pendiente).
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public bool Realizado { get; set; }

        public Evento(int id, string nombre, DateTime fecha, string lugar, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Fecha = fecha;
            Lugar = lugar;
            Descripcion = descripcion;
            Realizado = false;
        }

        public override string ToString()
        {
            string estado = Realizado ? "Realizado" : "Pendiente";
            return $"ID: {Id}, Nombre: {Nombre}, Fecha: {Fecha:dd/MM/yyyy}, Lugar: {Lugar}, Descripción: {Descripcion}, Estado: {estado}";
        }
    }
}