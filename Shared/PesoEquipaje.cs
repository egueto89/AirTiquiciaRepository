using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
   public class PesoEquipaje
    {
        public int IdPesoEquipaje { get; set; }

        
        public Int16 Peso { get; set; }

       
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El Peso es requerida")]
        [RegularExpression("([1-9][0-9]*)",ErrorMessage ="El peso no es válido")]
        public string PesoString { get; set; }

        [Required(ErrorMessage = "El Precio es requerida")]
        [Range(1,float.MaxValue, ErrorMessage = "El Precio no es válido")]
        public string PrecioString { get; set; }
    }
}
