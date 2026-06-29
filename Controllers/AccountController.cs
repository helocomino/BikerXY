using Microsoft.AspNetCore.Mvc;
using BikerXY.Data;
using BikerXY.Models;
using Microsoft.EntityFrameworkCore;

namespace BikerXY.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- REGISTRO ---

        // GET: /Account/Register (Muestra la pantalla)
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register (Recibe los datos del formulario)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el correo ya existe
                var existe = await _context.Usuarios.AnyAsync(u => u.Correo == usuario.Correo);
                if (existe)
                {
                    ModelState.AddModelError("Correo", "Este correo ya está registrado.");
                    return View(usuario);
                }

                // Guardar el usuario en la base de datos
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                // Una vez registrado, lo mandamos al Inicio de Sesión
                return RedirectToAction(nameof(Login));
            }
            return View(usuario);
        }

        // --- INICIO DE SESIÓN ---

        // GET: /Account/Login (Muestra la pantalla)
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login (Valida las credenciales)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string correo, string contrasena)
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                ViewBag.Error = "Todos los campos son obligatorios.";
                return View();
            }

            // Buscar si el usuario existe con esa contraseña
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Contrasena == contrasena);

            if (usuario != null)
            {
                // ¡Inicio de sesión exitoso! Por ahora lo redirigimos al Inicio de las Motos
                // Más adelante podemos usar Cookies para recordar la sesión
                return RedirectToAction("Index", "Motos");
            }

            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }

        // Cerrar Sesión
        public IActionResult Logout()
        {
            // Por ahora solo redirige al inicio
            return RedirectToAction("Index", "Home");
        }
    }
}