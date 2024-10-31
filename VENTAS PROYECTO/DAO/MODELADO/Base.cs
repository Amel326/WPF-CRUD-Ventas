using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.MODELADO
{
    public class Base
    {
        public byte Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public Base()
        {

        }

        public Base(byte estado, DateTime fechaRegistro, DateTime fechaActualizacion)
        {
            Estado = estado;
            FechaRegistro = fechaRegistro;
            FechaActualizacion = fechaActualizacion;
        }
    }
}
