using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class PersonaTripulacion
    {
        public int IdPersonaTripulacion { get; set; }

        [Required(ErrorMessage = "La persona es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La persona no es válido")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "La tripulación es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La tripulación no es válido")]
        public int IdTripulacion { get; set; }
    }
}
