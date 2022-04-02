using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class Tripulacion
    {
        public int IdTripulacion { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(100,ErrorMessage ="La descripción supera la cantidad de carácteres permitidos")]
        public string Descripcion { get; set; }
    }
}
