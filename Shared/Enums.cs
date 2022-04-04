using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public enum Tipos: byte
    {
        Nodefinido,
        Empleado,
        Cliente,
        MiembroTripulacion
    }

    public static class TiposDescripcion
    {

        public static string DevuelveDescripcion(this Tipos tipo)
        {
            string tipoPersona = "";
            switch (tipo)
            {
                case Tipos.Nodefinido:
                    tipoPersona= "Seleccione";
                    break;
                case Tipos.Empleado:
                    tipoPersona = "Empleado";
                    break;
                case Tipos.Cliente:
                    tipoPersona = "Cliente";
                    break;
                case Tipos.MiembroTripulacion:
                    tipoPersona = "Miembro Tripulacion";
                    break;
                default:
                    break;       
            }

            return tipoPersona;
        }
    }
}
