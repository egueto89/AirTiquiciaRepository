using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
  public  class LoginApp
    {
        [Required(ErrorMessage ="Ingrese un usuario") ]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Ingrese una contraseña")]
        public string Contrasena { get; set; }


        public string NombrePersona { get; set; }
    }
}
