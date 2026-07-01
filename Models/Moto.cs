using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikerXY.Models
{
    public class Moto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; } = string.Empty;

        [Required]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public int Anio { get; set; } // 🆕 Año de la moto

        [Required]
        public int Cilindrada { get; set; } // 🆕 Ej: 250, 600, 1000 (en cc)

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public string Estado { get; set; } = "Nueva"; // 🆕 "Nueva" o "Usada"

        [Required]
        public int Stock { get; set; } = 1;

        public string? Categoria { get; set; } = "General"; // Ej: Deportiva, Custom, Scooter

        public string? Descripcion { get; set; }

        public string? ImagenUrl { get; set; } // Foto principal estática

        public string? GifUrl { get; set; } // 🆕 Para el Lightbox interactivo en el detalle

        public bool EsDestacada { get; set; } = false; // 🆕 Para alimentar el Carrusel Dinámico superior
    }
}