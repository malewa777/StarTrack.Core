using Microsoft.AspNetCore.Mvc;

namespace StarTrack.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
