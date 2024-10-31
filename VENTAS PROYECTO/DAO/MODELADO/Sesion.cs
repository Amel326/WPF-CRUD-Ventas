using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MODELADO
{
    public static class Sesion
    {
        private static int idSesion;
        private static string rolSesion;
        private static string usuarioSesion;

        public static int IdSesion { get => idSesion; set => idSesion = value; }
        public static string RolSesion { get => rolSesion; set => rolSesion = value; }
        public static string UsuarioSesion { get => usuarioSesion; set => usuarioSesion = value; }

        public static string VerInfo()
        {
            return "Usuario: " + UsuarioSesion + ", Rol: " + RolSesion;
        }
    }
}
