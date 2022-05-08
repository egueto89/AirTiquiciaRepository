using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class TipoPasajero
    {
        public int IdTipoPasajero { get; set; }
        [Required(ErrorMessage ="la descripción es requerido.")]
        public string Descripcion { get; set; }
    }
}
