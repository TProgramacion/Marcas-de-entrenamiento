using Servicios;
using Modelos;
using System.Net.Http.Headers;

namespace Servicios
{
    public class GestorUsuarios
    {
        Dictionary<string, Usuario> listaUsuarios = new Dictionary<string, Usuario>();
        string? correoElectronico;
        string? contraseña;
        GestorEntrenamientos gestorEntrenamientos = new GestorEntrenamientos();

        public void RegistrarUsuario()
        {
            correoElectronico = IntroduceCorreo("registrar");
            if (correoElectronico != null)
            {
                contraseña = IntroduceContraseña("registrar", correoElectronico);
            }
        }

        public void LogearUsuario()
        {
            correoElectronico = IntroduceCorreo("logear");
            if (correoElectronico != null)
            {
                contraseña = IntroduceContraseña("logear", correoElectronico);
            }
        }

        private string IntroduceCorreo(string tipoMetodo)
        {
            string correoElectronico = null;
            while (correoElectronico == null)
            {
                Console.WriteLine("Por favor, introduce un correo electrónico");
                correoElectronico = Console.ReadLine();
                
                if (correoElectronico.ToUpper() == "ESC" || correoElectronico.ToUpper() == "CANCELAR" || correoElectronico.ToUpper() == "SALIR")
                {
                    Console.WriteLine("Operación cancelada.");
                    return null;
                }

                if (string.IsNullOrWhiteSpace(correoElectronico))
                {
                    Console.WriteLine("Error: no puedes dejar el correo vacío.");
                    continue;
                }
                else
                {
                    if (tipoMetodo == "registrar")
                    {
                        if (listaUsuarios.ContainsKey(correoElectronico))
                        {
                            Console.WriteLine($"Correo electrónico ya registrado, por favor inicie sesión con el correo electrónico {correoElectronico}");
                            correoElectronico = null;
                            continue;
                        }
                    }
                    else
                    {
                        if (!listaUsuarios.ContainsKey(correoElectronico))
                        {
                            Console.WriteLine($"Correo electrónico no registrado, por favor regístrese con el correo {correoElectronico} antes de logearse");
                            correoElectronico = null;
                            continue;
                        }
                    }
                }
                
            }
            return correoElectronico;

        }
        private string IntroduceContraseña(string tipoMetodo, string correoElectronico)
        {  
            string contraseña = null;
           while (contraseña == null)
            {
                Console.WriteLine("Por favor, introduce una contraseña");
                contraseña = Console.ReadLine();

                if (contraseña.ToUpper() == "ESC" || contraseña.ToUpper() == "CANCELAR" || contraseña.ToUpper() == "SALIR")
                {
                    Console.WriteLine("Operación cancelada.");
                    return null;
                }

                Usuario usuario = new Usuario(correoElectronico, contraseña);

                if (string.IsNullOrWhiteSpace(contraseña))
                {
                    Console.WriteLine("No puedes dejar la contraseña vacía.");
                    continue;
                }

                if (tipoMetodo == "registrar")
                {

                    if (listaUsuarios.TryAdd(correoElectronico, usuario))
                    {
                        Console.WriteLine($"Usuario {correoElectronico} registrado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("El usuario no ha podido registrarse correctamente, por favor vuelvelo a intentar");
                        contraseña = null;
                        continue;
                    }

                }
                else
                {
                    listaUsuarios.TryGetValue(correoElectronico, out Usuario usuarioEncontrado);
                    if (usuarioEncontrado.Contraseña  == contraseña)
                    {
                        if (gestorEntrenamientos == null)
                        {
                            gestorEntrenamientos = new GestorEntrenamientos();
                        }
                        gestorEntrenamientos.MostrarSubmenu(correoElectronico);
                    }
                    else
                    {
                        Console.WriteLine("Contraseña incorrecta, por favor vuelvelo a intentar");
                        contraseña = null;
                        continue;
                    }
                }
                
            }
            
            return contraseña;

        }
    }

}
