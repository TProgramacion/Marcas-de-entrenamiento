namespace Modelos{
public class Usuario
    {
        public string? CorreoElectronico {get; set;}
        public string? Contraseña {get; set;}

        public Usuario(string correoElectronico, string contraseña)
        {
            CorreoElectronico = correoElectronico;
            Contraseña = contraseña;
        }
    }
}