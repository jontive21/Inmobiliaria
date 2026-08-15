using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Propietario
    {
        public int IdPropietario { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100)]
        public string Apellido { get; set; } = "";

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(20)]
        public string Dni { get; set; } = "";

        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? Telefono { get; set; }

        public override string ToString()
            => $"{Nombre} {Apellido} ({Dni})";
    }
}