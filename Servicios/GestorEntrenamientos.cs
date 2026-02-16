using Servicios;
using Modelos;

namespace Servicios
{
    public class GestorEntrenamientos
    {
        Dictionary<string, List<Entrenamiento>> listaDeEntrenamientosPorUsuario = new Dictionary<string, List<Entrenamiento>>();
        public void MostrarSubmenu(string correoElectronico)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine($"\nUsuario {correoElectronico}:");
                Console.WriteLine("1. Registrar un entrenamiento");
                Console.WriteLine("2. Listar entrenamientos");
                Console.WriteLine("3. Vaciar entrenamientos");
                Console.WriteLine("4. Cerrar sesión\n");

                string input = Console.ReadLine();
                int subOpcion;
                if (!int.TryParse(input, out subOpcion))
                {
                    Console.WriteLine("Por favor, introduce una opción correcta");
                    continue;
                }

                switch (subOpcion)
                {
                    case 1:
                        Console.WriteLine("Por favor, introduce la distancia recorrida en km");
                        string entradaDistancia = Console.ReadLine();
                        double distancia;
                        if (!double.TryParse(entradaDistancia, out distancia))
                        {
                            Console.WriteLine("Error al introducir la distancia recorrida en km, utilice el formato adecuado.");
                            break;
                        }
                        Console.WriteLine("Por favor, introduce el tiempo empleado con el siguiento formato HH:MM:SS");
                        string entradaTiempo = Console.ReadLine();
                        TimeSpan tiempo;
                        if (!TimeSpan.TryParse(entradaTiempo, out tiempo))
                        {
                            Console.WriteLine("Error al introducir el tiempo empleado, utilice el formato adecuado (HH:MM:SS).");
                            break;
                        }

                        Entrenamiento entrenamiento = new Entrenamiento();
                        entrenamiento.distanciaRecorrida = distancia;
                        entrenamiento.tiempoEmpleado = tiempo;

                        if (!listaDeEntrenamientosPorUsuario.ContainsKey(correoElectronico))
                        {
                            listaDeEntrenamientosPorUsuario[correoElectronico] = new List<Entrenamiento>();
                        }
                        listaDeEntrenamientosPorUsuario[correoElectronico].Add(entrenamiento);

                        break;

                    case 2:
                        Console.WriteLine($"Entrenamientos del usuario {correoElectronico}:");
                        if (!listaDeEntrenamientosPorUsuario.ContainsKey(correoElectronico) || listaDeEntrenamientosPorUsuario[correoElectronico].Count == 0)
                        {
                            Console.WriteLine("No hay entrenamientos registrados\n");
                        }
                        else
                        {
                            int numeroEntrenamientos = 1;
                            foreach (Entrenamiento entrene in listaDeEntrenamientosPorUsuario[correoElectronico])
                            {
                                Console.WriteLine($"\nEntrenamiento {numeroEntrenamientos}:");
                                Console.WriteLine($"Distancia recorrida en el entrenamiento: {entrene.distanciaRecorrida} km");
                                Console.WriteLine($"Tiempo empleado en el entrenamiento: {entrene.tiempoEmpleado.Hours} horas {entrene.tiempoEmpleado.Minutes} minutos y {entrene.tiempoEmpleado.Seconds} segundos");
                                numeroEntrenamientos++;
                            }
                        }

                        break;

                    case 3:
                        if (listaDeEntrenamientosPorUsuario.ContainsKey(correoElectronico))
                        {
                            listaDeEntrenamientosPorUsuario[correoElectronico].Clear();
                            Console.WriteLine($"Entrenamientos del usuario {correoElectronico} borrados\n");
                        }
                        else
                        {
                            Console.WriteLine($"No existen entrenamientos del usuario {correoElectronico} a borrar.\n");
                        }

                        break;

                    case 4:
                        Console.WriteLine($"Sesión del usuario {correoElectronico} cerrada\n");
                        salir = true;
                        break;
                }
            }
        }
    }

}