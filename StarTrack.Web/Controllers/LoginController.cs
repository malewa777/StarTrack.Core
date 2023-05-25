using Microsoft.AspNetCore.Mvc;

namespace StarTrack.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
