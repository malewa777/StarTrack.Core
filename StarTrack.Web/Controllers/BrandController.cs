using Microsoft.AspNetCore.Mvc;

namespace StarTrack.Web.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            string test = "test";
            return View();
        }
    }
}
