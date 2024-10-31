using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MODELADO
{
    public class Usuario : Base
    {
        public short Id { get; set; }
        public String Ci { get; set; }
        public String Nombres { get; set; }
        public String PrimerApellido { get; set; }
        public String SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Sexo { get; set; }
        public String Rol { get; set; }
        public String NombreUsuario { get; set; }
        public String Password { get; set; }

        public Usuario()
        {

        }

        public Usuario(string ci, string nombres, string primerApellido, string segundoApellido, DateTime fechaNacimiento, string sexo, string rol)
        {
            Ci = ci;
            Nombres = nombres;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
            Rol = rol;
        }

        public Usuario(short id, string ci, string nombres, string primerApellido, string segundoApellido, DateTime fechaNacimiento, string sexo, string rol, string nombreUsuario, string contrasenia,
                        byte estado, DateTime fechaRegistro, DateTime fechaActualizacion)
           : base(estado, fechaRegistro, fechaActualizacion)
        {
            Id = id;
            Ci = ci;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
            Rol = rol;
            NombreUsuario = nombreUsuario;
            Password = contrasenia;
        }

        public Usuario(short id, string nombres, string ci, string primerApellido, string segundoApellido, string rol, string nombreUsuario, string contrasenia)
        {
            NombreUsuario = nombreUsuario;
            Password = contrasenia;
        }
        public string GenerarUsuario()
        {

            string parteNombre = Nombres.Length >= 3 ? Nombres.Substring(0, 3) : Nombres;
            string parteApellido = PrimerApellido.Length >= 3 ? PrimerApellido.Substring(0, 3) : PrimerApellido;
            string parteCarnet = Ci.Length >= 3 ? Ci.Substring(0, 3) : Ci;


            string usuario = parteNombre + parteApellido + parteCarnet;

            return usuario;
        }
        public bool ValidarContraseña(string contraseña)
        {

            if (contraseña.Length < 8)
            {
                return false;
            }
            else
            {
                bool Mayuscula = false;
                bool Minuscula = false;
                bool numero = false;

                foreach (char c in contraseña)
                {
                    if (char.IsUpper(c))
                    {
                        Mayuscula = true;
                    }
                    else if (char.IsLower(c))
                    {
                        Minuscula = true;
                    }else if (char.IsDigit(c))
                    {
                        numero = true;
                    }
                    if (Mayuscula && Minuscula && numero)
                    {
                        return true;
                    }
                }
            }


            return false;
        }
        
    }
}
