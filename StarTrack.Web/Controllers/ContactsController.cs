using Microsoft.AspNetCore.Mvc;

namespace StarTrack.Web.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
