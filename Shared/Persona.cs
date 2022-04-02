using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared
{
    public class Persona
    {
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El Nombre es requerida")]
        [StringLength(100, ErrorMessage = "El Nombre supera la cantidad de caracteres permitidos")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es requerida")]
        [StringLength(100, ErrorMessage = "El Apellido supera la cantidad de caracteres permitidos")]
        public string Apellidos { get; set; }

        [StringLength(50, ErrorMessage = "El Teléfono supera la cantidad de caracteres permitidos")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{4})[-. ]?([0-9]{4})$", ErrorMessage = "Teléfono no válido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La Dirección es requerida")]
        [StringLength(250, ErrorMessage = "La Dirección supera la cantidad de caracteres permitidos")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Correo es requerida")]
        [StringLength(150, ErrorMessage = "El Correo supera la cantidad de caracteres permitidos")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Correo electrónico no válido")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Correo electrónico no válido")]
        public string Correo { get; set; }
    }
}
