using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class Vuelo
    {
        public int IdVuelo { get; set; }
        public int IdTipoVuelo { get; set; }
        public int IdAvion { get; set; }
        public int IdDestino { get; set; }
        public int IdDestinoLlegada { get; set; }
        public int IdPersonaTripulacion { get; set; }
        public string NumeroVuelo { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public Int16 HoraSalida { get; set; }
        public Int16 MinutosSalida { get; set; }
        public Int16 DuracionHoraVuelo { get; set; }
        public Int16 DuracionMinutosVuelo { get; set; }
        public Int16 HoraLlegada{ get; set; }
        public Int16 MinutosLlegada { get; set; }


        #region descripcion de llaves

        public string TipoVueloDescripcion { get; set; }

        public string AvionDescripcion { get; set; }

        public string DestinoDescripcion { get; set; }

        public string DestinoLlegada { get; set; }

        public string PersoTripu { get; set; }

        #endregion  

    }
}
