using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
   public class TipoAvion
    {
        public int IdTipoAvion { get; set; }
        public string Descripcion { get; set; }
        public Int16 Fila { get; set; }
        public Int16 Asiento { get; set; }

        [Required(ErrorMessage = "El Fila es requerida")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "La Fila no es válido")]
        public string FilaString { get; set; }

        [Required(ErrorMessage = "El Asiento es requerida")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "El Asiento no es válido")]
        public string AsientoString { get; set; }
    }
}
