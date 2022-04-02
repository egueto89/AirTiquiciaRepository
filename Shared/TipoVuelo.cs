using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class TipoVuelo
    {
        public int IdTipoVuelo { get; set; }
        [Required(ErrorMessage = "El tipo de vuelo es requerido.")]
        [StringLength(150, ErrorMessage = "El tipo de vuelo supera la cantidad de caracteres permitido")]
        public string Descripcion { get; set; }
    }
}
