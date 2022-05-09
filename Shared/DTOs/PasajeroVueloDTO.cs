using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTiquiciaAPP.Shared.DTOs
{
    public class PasajeroVueloDTO
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
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Correo electrónico no válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La Identificación es requerida")]
        public string Identificacion { get; set; }


        #region Pasajero

        [Required(ErrorMessage = "La cantidad de Equipaje es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de Equipaje es requerida")]
        public int cantidadEquipaje { get; set; }

        [Required(ErrorMessage = "El Tipo de Pasajero es requerida")]
        public string TipoPasajero { get; set; }
        #endregion

        #region PesoEquipaje

        [Range(1, int.MaxValue, ErrorMessage = "El Peso del Equipaje es requerida")]
        public int IdPesoEquipaje { get; set; }
        public decimal precioEquipaje { get; set; }
        public int pesoEquipaje { get; set; }


        public string numeroVuelo { get; set; }
        #endregion


    }
}
