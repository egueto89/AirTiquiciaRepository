using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared.DTOs
{
    public class ResumenVueloDTO
    {
        public string HoraSalida { get; set; }
        public string HoraLlegada { get; set; }
        public string DestinoSalida { get; set; }
        public string DestinoLlegada { get; set; }

        public decimal Precio { get; set; }

        public int CantidadEquipaje { get; set; }
        public decimal PrecioEquipaje { get; set; }
        public Int16 DuracionHoraVuelo { get; set; }

        public DateTime FechaCompra { get; set; }

        public string NumeroVuelo { get; set; }
        public string Aviondescripcion { get; set; }
        public string Aereolina { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }


    }
}
