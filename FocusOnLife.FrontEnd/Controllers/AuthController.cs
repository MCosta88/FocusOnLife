using Microsoft.AspNetCore.Mvc;

namespace FocusOnLife.FrontEnd.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            // Passa para o layout que a página atual é a de login
            ViewData["IsLoginPage"] = true;
            return View();
        }

    }
}
