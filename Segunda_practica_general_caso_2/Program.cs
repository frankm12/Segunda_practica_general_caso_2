using System;
using System.Collections.Generic;

namespace SistemaSeguimientoTareas
{
    class Tarea
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaLimite { get; set; }

        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"Título: {Titulo}, Descripción: {Descripcion}, Fecha Límite: {FechaLimite.ToShortDateString()}");
        }
    }
    class TareaUrgente : Tarea
    {
        public int NivelUrgencia { get; set; }

        public override void MostrarDetalles()
        {
            Console.WriteLine($"Título: {Titulo}, Descripción: {Descripcion}, Fecha Límite: {FechaLimite.ToShortDateString()}, Nivel de Urgencia: {NivelUrgencia}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Tarea> tareas = new List<Tarea>();
            bool continuar;

            do
            {
                Console.WriteLine("Sistema de Seguimiento de Tareas");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Ver Tareas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el título de la tarea: ");
                        string titulo = Console.ReadLine();

                        Console.Write("Ingrese la descripción de la tarea: ");
                        string descripcion = Console.ReadLine();

                        Console.Write("Ingrese la fecha límite (dd/MM/yyyy): ");
                        DateTime fechaLimite;
                        while (!DateTime.TryParse(Console.ReadLine(), out fechaLimite))
                        {
                            Console.Write("Fecha no válida. Ingrese nuevamente la fecha límite (dd/MM/yyyy): ");
                        }

                        Console.Write("¿Es una tarea urgente? (si/no): ");
                        string esUrgente = Console.ReadLine().ToLower();

                        if (esUrgente == "si")
                        {
                            Console.Write("Ingrese el nivel de urgencia (1-10): ");
                            int nivelUrgencia;
                            while (!int.TryParse(Console.ReadLine(), out nivelUrgencia) || nivelUrgencia < 1 || nivelUrgencia > 10)
                            {
                                Console.Write("Nivel de urgencia no válido. Ingrese un número entre 1 y 10: ");
                            }

                            TareaUrgente tareaUrgente = new TareaUrgente()
                            {
                                Titulo = titulo,
                                Descripcion = descripcion,
                                FechaLimite = fechaLimite,
                                NivelUrgencia = nivelUrgencia
                            };
                            tareas.Add(tareaUrgente);
                        }
                        else
                        {
                            Tarea tarea = new Tarea()
                            {
                                Titulo = titulo,
                                Descripcion = descripcion,
                                FechaLimite = fechaLimite
                            };
                            tareas.Add(tarea);
                        }

                        Console.WriteLine("Tarea agregada exitosamente.\n");
                        break;

                    case "2":
                        Console.WriteLine("\nLista de Tareas:");
                        foreach (Tarea tarea in tareas)
                        {
                            tarea.MostrarDetalles();
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                        break;
                }

                Console.Write("¿Desea realizar otra acción? (si/no): ");
                continuar = Console.ReadLine().ToLower() == "si";

            } while (continuar);

            Console.WriteLine("Gracias por usar el Sistema de Seguimiento de Tareas.");
        }
    }
}
