using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
   public class TipoPersona
    {
        public int IdTipoPersona { get; set; }

        [Required(ErrorMessage = "La persona es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una persona")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El tipo es requerida")]
        [StringLength(50, ErrorMessage ="El tipo supera la cantidad permitida")]
        public string Tipo { get; set; }

        public string NombrePersona { get; set; }

    }
}
