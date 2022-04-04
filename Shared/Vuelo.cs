using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class Vuelo
    {

        public Vuelo(){

            FechaSalida = DateTime.Now;
            FechaLlegada =  DateTime.Now.AddDays(2);
            }
        public int IdVuelo { get; set; }

        [Required(ErrorMessage = "El tipo de vuelo es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "El tipo de vuelo no es válido")]
        public int IdTipoVuelo { get; set; }

        [Required(ErrorMessage = "El avión es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "El avión no es válido")]
        public int IdAvion { get; set; }

        [Required(ErrorMessage = "El destino es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "El destino no es válido")]
        public int IdDestino { get; set; }

        [Required(ErrorMessage = "El destino de llegada es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "El destino de llegada no es válido")]
        public int IdDestinoLlegada { get; set; }
        public int IdPersonaTripulacion { get; set; }

        [Required(ErrorMessage = "El número de vuelo es requerida")]
        public string NumeroVuelo { get; set; }

        [Required(ErrorMessage = "La fecha de salida es requerida")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "La fecha de llegada es requerida")]
        public DateTime FechaLlegada { get; set; }

        [Required(ErrorMessage = "La hora de salida es requerida")]
        [Range(0, 60, ErrorMessage = "La hora de salida es requerida")]
        public Int16 HoraSalida { get; set; }

        [Required(ErrorMessage = "Los minutos de salida son requeridos")]
        [Range(0, 60, ErrorMessage = "Los minutos de salida son requeridos")]
        public Int16 MinutosSalida { get; set; }

        [Required(ErrorMessage = "La duración del vuelo es requerida")]
        [Range(1, 23, ErrorMessage = "La duración del vuelo es requerida")]
        public Int16 DuracionHoraVuelo { get; set; }

        [Required(ErrorMessage = "Los minutos de duración del vuelo es requerida")]
        [Range(0, 60, ErrorMessage = "Los minutos de duración del vuelo es requerida")]
        public Int16 DuracionMinutosVuelo { get; set; }

        [Required(ErrorMessage = "La hora de llegada es requerida")]
        [Range(0, 23, ErrorMessage = "La hora de llegada es requerida")]
        public Int16 HoraLlegada{ get; set; }

        [Required(ErrorMessage = "Los minutos de llegada son requeridos")]

        [Range(0, 60, ErrorMessage = "Los minutos de llegada son requeridos")]
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
