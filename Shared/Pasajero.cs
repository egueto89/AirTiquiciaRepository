using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
   public class Pasajero
    {
        public int IdPasajero { get; set; }
        [Required(ErrorMessage = "La persona es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una persona")]
        public int IdPersona { get; set; }

        public Int16 CantidadEquipaje { get; set; }

        [Required(ErrorMessage = "La Cantidad de Equipaje es requerida")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "La Cantidad de Equipaje no es válido")]
        [Range(0, byte.MaxValue, ErrorMessage = "Cantidad de Equipaje no permitidas")]
        public string CantidadEquipajeString { get; set; }

        public string NombrePersona { get; set; }
    }

}
