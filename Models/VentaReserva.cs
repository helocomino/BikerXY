using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikerXY.Models
{
    public class VentaReserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; } // Quién compró/apartó

        [Required]
        public int MotoId { get; set; } // Qué moto compró

        [Required]
        public string TipoTransaccion { get; set; } = "Reserva"; // "Reserva" o "Venta Directa"

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        public DateTime FechaTransaccion { get; set; } = DateTime.UtcNow;

        // Propiedades de navegación (Para hacer Joins automáticos en C#)
        [ForeignKey("MotoId")]
        public Moto? Moto { get; set; }
    }
}