namespace Tarea03.Models
{
    // Representa un invitado a un evento.
    public class Invitado
    {
        public string Nombre { get; set; }
        public string Email { get; set; }

        public Invitado(string nombre, string email)
        {
            Nombre = nombre;
            Email = email;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Email: {Email}";
        }
    }
}