namespace BikerXY.Models
{
    public class CartItem
    {
        public int MotoId { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public int StockDisponible { get; set; } // Para validar que no pida más de lo que hay
        public decimal Total => Precio * Cantidad;
    }
}