using Microsoft.AspNetCore.Mvc;

namespace StarTrack.Web.Controllers
{
    public class DocsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
