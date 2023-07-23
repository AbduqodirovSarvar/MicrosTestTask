using Microsoft.AspNetCore.Mvc;

namespace Micros.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
