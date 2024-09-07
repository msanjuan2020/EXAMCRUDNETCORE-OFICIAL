using Microsoft.AspNetCore.Mvc;

namespace EXAMCRUDNETCORE.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Lógica de autenticación
            if (email == "usuario@ejemplo.com" && password == "password123")
            {
                // Redirigir al usuario a la página principal si las credenciales son correctas
                return RedirectToAction("Index", "Home");
            }

            // Si las credenciales son incorrectas, mostrar un mensaje de error
            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }
    }
}
