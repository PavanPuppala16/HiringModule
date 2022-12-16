using Microsoft.AspNetCore.Mvc;

namespace HiringOperation.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Adminlogin()
        {
            return View();
        }
        public IActionResult TrainerLogin()
        {
            return View();
        }
    }
}
