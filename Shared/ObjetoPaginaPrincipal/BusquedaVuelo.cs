using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class BusquedaVuelo
    {

        public BusquedaVuelo(){

            FechaSalida = DateTime.Now;
            FechaLlegada =  DateTime.Now.AddDays(2);
          //  MisPasajeros = new List<Pasajerovuelo>();
            }

        [Required(ErrorMessage = "El destino es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "El destino no es válido")]
        public int IdDestino { get; set; }

        [Required(ErrorMessage = "El destino de llegada es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "El destino de llegada no es válido")]
        public int IdDestinoLlegada { get; set; }

        [Required(ErrorMessage = "La fecha de salida es requerida")]
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }


        //public List<Pasajerovuelo> MisPasajeros { get; set; }


        //[Required(ErrorMessage = "El tipo de pasejero es requeridos")]
        //[Range(1, int.MaxValue, ErrorMessage = "El tipo de pasejero es requeridos")]
        //public int tipoPasajero { get; set; }

        [Required(ErrorMessage = "La cantidad pasejeros es requeridos")]

        [Range(1, 60, ErrorMessage = "La cantidad pasejeros es requeridos")]
        public Int16 CantidadPasajero { get; set; }


        [Required(ErrorMessage = "El tipo de viaje es requerida")]
        public string TipoViaje { get; set; }

        public string descripcionPasejero { get; set; }

    }

    public class Pasajerovuelo
    {
        public int tipoPasajero { get; set; }

        public string descripcionPasejero { get; set; }

 
        public Int16 CantidadPasajero { get; set; }

    }
}
