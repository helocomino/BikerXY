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
        public int Cilindrada { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        public string ImagenUrl { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        // 🆕 NUEVOS CAMPOS PARA STOCK Y FILTROS ADVANCED
        [Required]
        public int Stock { get; set; } = 0; // Control de inventario

        [Required]
        public string Ambiente { get; set; } = string.Empty; // Terreno, Pistera, Carretera

        public string Descripcion { get; set; } = string.Empty; // Ficha técnica básica
    }
}