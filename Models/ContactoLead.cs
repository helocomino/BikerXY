using System;
using System.ComponentModel.DataAnnotations;

namespace BikerXY.Models
{
    public class ContactoLead
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreCliente { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string CorreoCliente { get; set; } = string.Empty;

        public string? TelefonoCliente { get; set; }

        [Required]
        public string Mensaje { get; set; } = string.Empty;

        [Required]
        public string TipoSolicitud { get; set; } = "Contacto"; // "Contacto", "Cotizar", "Test Drive"

        [Required]
        public string Estado { get; set; } = "Pendiente"; // "Pendiente", "En Proceso", "Vendido", "Cancelado"

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Opcional: Vincular a qué moto está asociado el interés
        public int? MotoId { get; set; }
    }
}