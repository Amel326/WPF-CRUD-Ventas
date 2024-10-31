using DAO.MODELADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.INTERFAZ
{
    public interface IBase<Usuario>
    {
        int Insert(Usuario t);
        int Delete(Usuario t);
        int Update(Usuario t);

        int CambiarContraseña(Usuario t);
        int ValidarUsuario(Usuario t);

        DataTable Select();
        DataTable Login(string nombreUsuario, string contrasenia);
    }
}
