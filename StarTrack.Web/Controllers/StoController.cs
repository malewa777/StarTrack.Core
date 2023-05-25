using Microsoft.AspNetCore.Mvc;

namespace StarTrack.Web.Controllers
{
    public class StoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
