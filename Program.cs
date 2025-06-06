﻿using System;
using Tarea03.Servicios;
using Tarea03.Models;
using Tarea03.Clases;

namespace Tarea03
{
    //Programa principal que permite gestionar una agenda de eventos desde consola.
    //Utiliza una lista enlazada simple para almacenar los eventos y ofrece opciones para agregar, buscar,
    //marcar como realizado y mostrar eventos según su estado.
    class Program
    {
        static void Main(string[] args)
        {
            GestorEventos gestor = new GestorEventos();
            int opcion;

            do
            {
                //Menú principal
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("        GESTOR DE EVENTOS");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Agregar evento");
                Console.WriteLine("2. Agregar invitado a un evento");
                Console.WriteLine("3. Mostrar invitados de un evento");
                Console.WriteLine("4. Buscar evento");
                Console.WriteLine("5. Marcar evento como realizado");
                Console.WriteLine("6. Mostrar eventos pendientes");
                Console.WriteLine("7. Mostrar eventos realizados");
                Console.WriteLine("8. Mostrar todos los eventos");
                Console.WriteLine("0. Salir");
                Console.WriteLine("===================================");

                Console.Write("Seleccione una opción: ");
                string input = Console.ReadLine();
                while (!int.TryParse(input, out opcion) || opcion < 0 || opcion > 8)
                {
                    Console.Write("Opción inválida. Ingrese un número entre 0 y 8: ");
                    input = Console.ReadLine();
                }
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        //Agregar evento
                        Console.WriteLine("--- Agregar nuevo evento ---");
                        int id;
                        DateTime fecha;
                        Console.Write("ID: ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("ID inválido. Ingrese un número: ");
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.Write("El nombre no puede estar vacío. Ingrese un nombre: ");
                            nombre = Console.ReadLine();
                        }

                        Console.Write("Fecha (dd/mm/yyyy): ");
                        while (!DateTime.TryParse(Console.ReadLine(), out fecha))
                            Console.Write("Fecha inválida. Ingrese en formato dd/mm/yyyy: ");

                        Console.Write("Lugar: ");
                        string lugar = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(lugar))
                        {
                            Console.Write("El lugar no puede estar vacío. Ingrese un lugar: ");
                            lugar = Console.ReadLine();
                        }

                        Console.Write("Descripción: ");
                        string descripcion = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(descripcion))
                        {
                            Console.Write("La descripción no puede estar vacía. Ingrese una descripción: ");
                            descripcion = Console.ReadLine();
                        }
                        gestor.AgregarEvento(id, nombre, fecha, lugar, descripcion);
                        Console.WriteLine("\nEvento agregado exitosamente.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        //Agregar invitado a un evento
                        Console.WriteLine("--- Agregar invitado a un evento ---");
                        Console.Write("Ingrese el ID del evento: ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("ID inválido. Ingrese un número: ");
                        Evento eventoInv = gestor.BuscarEvento(id);
                        if (eventoInv != null)
                        {
                            Console.Write("Nombre del invitado: ");
                            string nombreInv = Console.ReadLine();
                            Console.Write("Email del invitado: ");
                            string emailInv = Console.ReadLine();
                            eventoInv.Invitados.Agregar(new Invitado(nombreInv, emailInv));
                            Console.WriteLine("Invitado agregado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Evento no encontrado.");
                        }
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        //Mostrar invitados de un evento
                        Console.WriteLine("--- Mostrar invitados de un evento ---");
                        Console.Write("Ingrese el ID del evento: ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("ID inválido. Ingrese un número: ");
                        Evento eventoMostrar = gestor.BuscarEvento(id);
                        if (eventoMostrar != null)
                        {
                            var invitados = eventoMostrar.Invitados.ObtenerTodos();
                            if (invitados.Count == 0)
                                Console.WriteLine("No hay invitados registrados para este evento.");
                            else
                                foreach (var inv in invitados)
                                    Console.WriteLine(inv);
                        }
                        else
                        {
                            Console.WriteLine("Evento no encontrado.");
                        }
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        //Buscar evento por ID
                        Console.WriteLine("--- Buscar evento por ID ---");
                        Console.Write("Ingrese el ID a buscar: ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("ID inválido. Ingrese un número: ");
                        Evento encontrado = gestor.BuscarEvento(id);
                        if (encontrado != null)
                            Console.WriteLine($"\n{encontrado}");
                        else
                            Console.WriteLine("\nEvento no encontrado.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        //Marcar evento como realizado
                        Console.WriteLine("--- Marcar evento como realizado ---");
                        Console.Write("Ingrese el ID del evento: ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("ID inválido. Ingrese un número: ");
                        if (gestor.MarcarComoRealizado(id))
                            Console.WriteLine("\nEvento marcado como realizado.");
                        else
                            Console.WriteLine("\nEvento no encontrado o ya realizado.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 6:
                        //Mostrar eventos pendientes
                        Console.WriteLine("--- Eventos pendientes ---");
                        var pendientes = gestor.ObtenerPendientes();
                        if (pendientes.Count == 0)
                            Console.WriteLine("No hay eventos pendientes.");
                        else
                            foreach (var e in pendientes)
                                Console.WriteLine(e);
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 7:
                        //Mostrar eventos realizados
                        Console.WriteLine("--- Eventos realizados ---");
                        var realizados = gestor.ObtenerRealizados();
                        if (realizados.Count == 0)
                            Console.WriteLine("No hay eventos realizados.");
                        else
                            foreach (var e in realizados)
                                Console.WriteLine(e);
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 8:
                        //Mostrar todos los eventos
                        Console.WriteLine("--- Lista de todos los eventos ---");
                        var eventos = gestor.ObtenerTodos();
                        if (eventos.Count == 0)
                            Console.WriteLine("No hay eventos registrados.");
                        else
                            foreach (var e in eventos)
                                Console.WriteLine(e);
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 0);
        }
    }
}