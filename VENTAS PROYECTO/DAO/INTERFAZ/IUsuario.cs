using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.MODELADO;

namespace DAO.INTERFAZ
{
    public interface IUsuario : IBase <Usuario>
    {
        Usuario Get(byte id);
    }
}
