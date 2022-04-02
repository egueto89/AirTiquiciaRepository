using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
   public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "La persona es requerida")]
        [Range(1,int.MaxValue, ErrorMessage ="Debe seleccionar una persona")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El Usuario es requerida")]
        [StringLength(100, ErrorMessage = "El Usuario supera la cantidad de caracteres permitidos")]
        public string UsuarioSistema { get; set; }

        [Required(ErrorMessage = "La Contraseña es requerida")]
        [StringLength(100, ErrorMessage = "La Contraseña supera la cantidad de caracteres permitidos")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "El Rol es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un rol")]
        public int IdRol { get; set; }

        public string NombrePersona { get; set; }
        public string DescripcionRol { get; set; }
    }
}
