using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class Destino
    {
        public int IdDestino { get; set; }
        [Required(ErrorMessage ="El nombre del destino es requerido.")]
        public string Nombre { get; set; }
    }
}
