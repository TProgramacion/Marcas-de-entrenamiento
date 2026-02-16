using Servicios;

class MarcasDeEntrenamiento
{
    static void Main(string[] args)
    {
        int opcion = -1;
        GestorUsuarios gestor = new GestorUsuarios();
        do
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Logear usuario");
            Console.WriteLine("3. Salir de la aplicación\n");
            string seleccion = Console.ReadLine();
            if(!int.TryParse(seleccion, out opcion)){
                Console.WriteLine("Por favor, elige una opción del menú válida");
                continue;
            }
            ;

            switch (opcion)
            {
                case 1:
                    gestor.RegistrarUsuario();
                    break;

                case 2:
                    gestor.LogearUsuario();
                    break;

                case 3:
                    Console.WriteLine("Cerrando la aplicación");
                    break;

                default:
                    Console.WriteLine("Por favor, elige una opción del menú válida");
                    break;

            }
        }
        while (opcion != 3);
    }
}