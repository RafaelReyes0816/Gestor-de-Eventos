# Gestor de Eventos con Lista Enlazada en C#

Este proyecto es una aplicación de consola que permite gestionar una agenda de eventos utilizando una **lista enlazada simple** y programación orientada a objetos en C#. Es ideal para demostrar el uso de estructuras de datos dinámicas y buenas prácticas de organización de código.

## Funcionalidades

- **Agregar evento:** Permite registrar un nuevo evento con ID, nombre, fecha, lugar y descripción.
- **Buscar evento:** Busca un evento por su ID y muestra sus detalles.
- **Marcar evento como realizado:** Permite marcar un evento como realizado.
- **Mostrar eventos pendientes:** Lista solo los eventos que aún no han sido realizados.
- **Mostrar eventos realizados:** Lista solo los eventos que ya han sido realizados.
- **Mostrar todos los eventos:** Lista todos los eventos registrados, indicando su estado.
- **Salir:** Finaliza la aplicación.

## Estructura del Proyecto

- `Models/Evento.cs`: Clase que representa un evento.
- `Estructuras/ListaEnlazada.cs`: Implementación de la lista enlazada simple.
- `Servicios/GestorEventos.cs`: Lógica para gestionar los eventos.
- `Program.cs`: Menú principal e interacción con el usuario.

## Ejecución

1. Abre la carpeta del proyecto en Visual Studio o Visual Studio Code.
2. Compila y ejecuta el archivo `Program.cs`.
3. Sigue las instrucciones del menú para gestionar tus eventos.

## Ejemplo de Uso

```
--- Menú de Eventos ---
1. Agregar evento
2. Buscar evento
3. Marcar evento como realizado
4. Mostrar eventos pendientes
5. Mostrar eventos realizados
6. Mostrar todos los eventos
0. Salir
Seleccione una opción: 1
ID: 1
Nombre: Fiesta
Fecha (dd/mm/yyyy): 25/05/2025
Lugar: Salón Comunal
Descripción: Fiesta de fin de curso
Evento agregado exitosamente.
```

---

**Autor:** [Rafael Reyes]  
**Materia:** Estructuras de Datos  
**Año:** 2025