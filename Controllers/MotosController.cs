using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikerXY.Data;

namespace BikerXY.Controllers
{
    public class MotosController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Inyectamos el contexto de la base de datos
        public MotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Esta acción cargará la página principal del catálogo
        public async Task<IActionResult> Index()
        {
            // Trae todas las motos desde la base de datos en Render
            var listaMotos = await _context.Motos.ToListAsync();

            // Se las envía a la vista (pantalla)
            return View(listaMotos);
        }
    }
}