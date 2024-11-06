using Microsoft.AspNetCore.Mvc;

namespace VATPrompt_AngularJs_V2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("login");
        }
    }
}
