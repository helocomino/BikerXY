using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikerXY.Models
{
    public class Moto
    {
        [Key] // Esto le dice a la base de datos que es el ID único (Llave Primaria)
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; } = string.Empty;

        [Required]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        public int Cilindrada { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Formato correcto para dinero en PostgreSQL
        public decimal Precio { get; set; }

        // Aquí guardaremos el link de internet de la imagen para evitar que Render la borre
        public string ImagenUrl { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;
    }
}