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

        // 📋 1. LISTADO PRINCIPAL: /Admin
        public async Task<IActionResult> Index()
        {
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
            // Forzamos un valor por defecto para evitar que falle por la categoría ausente
            if (string.IsNullOrEmpty(moto.Categoria))
            {
                moto.Categoria = "General";
            }

            // Limpiamos errores de validación de campos que el formulario no maneja
            ModelState.Remove("Categoria");

            if (ModelState.IsValid)
            {
                _context.Add(moto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // 👈 Te saca y te manda al listado actualizado
            }
            return View(moto);
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
        // ✏️ EDITAR (Procesar la actualización)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Moto moto)
        {
            if (id != moto.Id) return NotFound();

            if (string.IsNullOrEmpty(moto.Categoria))
            {
                moto.Categoria = "General";
            }

            ModelState.Remove("Categoria");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); // 👈 Te saca y te manda al listado actualizado
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Motos.Any(e => e.Id == moto.Id)) return NotFound();
                    else throw;
                }
            }
            return View(moto);
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