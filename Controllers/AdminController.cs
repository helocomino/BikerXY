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
            if (ModelState.IsValid)
            {
                _context.Add(moto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Moto moto)
        {
            if (id != moto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Motos.Any(e => e.Id == moto.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
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