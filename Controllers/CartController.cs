using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BikerXY.Data;
using BikerXY.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BikerXY.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🔹 Ver el carrito: /Cart
        public IActionResult Index()
        {
            var cart = GetCartFromSession();
            return View(cart);
        }

        // 🔹 Agregar producto al carrito (Mejorado con validación de Stock)
        [HttpPost]
        public async Task<IActionResult> AddToCart(int motoId)
        {
            // Validar si el usuario inició sesión
            if (HttpContext.Session.GetString("UsuarioNombre") == null)
            {
                return Json(new { success = false, message = "Debes iniciar sesión." });
            }

            var moto = await _context.Motos.FindAsync(motoId);
            if (moto == null || moto.Stock <= 0)
            {
                return Json(new { success = false, message = "Moto no disponible o sin stock." });
            }

            var cart = GetCartFromSession();
            var cartItem = cart.FirstOrDefault(c => c.MotoId == motoId);

            if (cartItem == null)
            {
                cart.Add(new CartItem
                {
                    MotoId = moto.Id,
                    Marca = moto.Marca,
                    Modelo = moto.Modelo,
                    Precio = moto.Precio,
                    ImagenUrl = moto.ImagenUrl,
                    Cantidad = 1,
                    StockDisponible = moto.Stock
                });
            }
            else
            {
                // Validar que no supere el stock real en la base de datos
                if (cartItem.Cantidad < moto.Stock)
                {
                    cartItem.Cantidad++;
                }
                else
                {
                    return Json(new { success = false, message = $"Lo sentimos, solo quedan {moto.Stock} unidades en stock." });
                }
            }

            SaveCartToSession(cart);

            // Devolvemos el total de items en el carrito para actualizar el menú superior
            var totalItems = cart.Sum(c => c.Cantidad);
            return Json(new { success = true, totalItems });
        }

        // 🔹 Eliminar un producto del carrito
        public IActionResult RemoveFromCart(int motoId)
        {
            var cart = GetCartFromSession();
            var item = cart.FirstOrDefault(c => c.MotoId == motoId);
            if (item != null)
            {
                cart.Remove(item);
            }
            SaveCartToSession(cart);
            return RedirectToAction("Index");
        }

        // 🛠️ Métodos auxiliares para gestionar la Sesión de forma limpia
        private List<CartItem> GetCartFromSession()
        {
            var sessionData = HttpContext.Session.GetString("CarritoCompra");
            return sessionData == null ? new List<CartItem>() : JsonSerializer.Deserialize<List<CartItem>>(sessionData);
        }

        private void SaveCartToSession(List<CartItem> cart)
        {
            HttpContext.Session.SetString("CarritoCompra", JsonSerializer.Serialize(cart));
        }
    }
}