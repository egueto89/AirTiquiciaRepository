using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class Rol
    {
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre del rol es requerido.")]
        [StringLength(50, ErrorMessage = "El Nombre supera la cantidad de caracteres permitido")]
        public string Nombre { get; set; }
    }
}
