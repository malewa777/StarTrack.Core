using Microsoft.AspNetCore.Mvc;

namespace StarTrack.Web.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
