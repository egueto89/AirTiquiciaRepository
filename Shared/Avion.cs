using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class Avion
    {
        public int IdAvion { get; set; }

        [Required(ErrorMessage = "El tipoAvion es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipoAvion")]
        public int IdTipoAvion { get; set; }
        [Required(ErrorMessage = "El Nombre avión es requerida")]
        [StringLength(150, ErrorMessage = "El Nombre avión  supera la cantidad de caracteres permitidos")]
        public string Descripcion { get; set; }

        public string DescripcionTipoAvion { get; set; }

    }
}
