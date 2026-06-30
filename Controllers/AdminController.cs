using Microsoft.AspNetCore.Mvc;
using BikerXY.Data;
using BikerXY.Models;
using Microsoft.EntityFrameworkCore;

namespace BikerXY.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 📋 1. LISTADO PRINCIPAL: /Admin (Protegido de intrusos)
        public async Task<IActionResult> Index()
        {
            // Obtener los datos de sesión actuales
            var usuarioEmail = HttpContext.Session.GetString("UsuarioEmail");

            // 🔒 CANDADO DE SEGURIDAD: Solo permite tu correo de administrador definitivo
            if (string.IsNullOrEmpty(usuarioEmail) || usuarioEmail.ToLower() != "adminxy@gmail.com")
            {
                // Si no eres tú, te bota directo al Login
                return RedirectToAction("Login", "Account");
            }

            var motos = await _context.Motos.ToListAsync();
            return View(motos);
        }

        // ➕ 2. CREAR (Vista formulario)
        public IActionResult Create()
        {
            return View();
        }

        // ➕ CREAR (Procesar el formulario)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Moto moto)
        {
            // Forzamos valores básicos por si acaso
            if (string.IsNullOrEmpty(moto.Categoria)) moto.Categoria = "General";
            if (string.IsNullOrEmpty(moto.Descripcion)) moto.Descripcion = string.Empty;

            // Guardamos directamente en la base de datos saltando el validador estricto
            _context.Add(moto);
            await _context.SaveChangesAsync();

            // Te saca de la pantalla obligatoriamente y te manda al listado actualizado
            return RedirectToAction(nameof(Index));
        }

        // ✏️ 3. EDITAR (Vista formulario con datos cargados)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound();

            return View(moto);
        }

        // ✏️ EDITAR (Procesar la actualización)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Moto moto)
        {
            if (id != moto.Id) return NotFound();

            // Forzamos valores básicos por si acaso
            if (string.IsNullOrEmpty(moto.Categoria)) moto.Categoria = "General";
            if (string.IsNullOrEmpty(moto.Descripcion)) moto.Descripcion = string.Empty;

            try
            {
                // Forzamos la actualización directa de la entidad en la base de datos
                _context.Update(moto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Motos.Any(e => e.Id == moto.Id)) return NotFound();
                else throw;
            }

            // Te saca de la pantalla obligatoriamente y te manda al listado actualizado
            return RedirectToAction(nameof(Index));
        }

        // 🗑️ 4. BORRAR
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var moto = await _context.Motos.FindAsync(id);
            if (moto != null)
            {
                _context.Motos.Remove(moto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}