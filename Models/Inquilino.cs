using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Inquilino
    {
        public int IdInquilino { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(20)]
        public string Dni { get; set; } = "";

        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [StringLength(150)]
        public string NombreCompleto { get; set; } = "";

        [StringLength(50)]
        public string? Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        [StringLength(150)]
        public string? Email { get; set; }

        public override string ToString()
            => $"{NombreCompleto} ({Dni})";
    }
}