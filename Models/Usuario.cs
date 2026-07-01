using System.ComponentModel.DataAnnotations;

namespace BikerXY.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Contrasena { get; set; } = string.Empty;

        [Required]
        public string Rol { get; set; } = "Cliente"; // 🆕 "Admin", "Vendedor" o "Cliente"
    }
}