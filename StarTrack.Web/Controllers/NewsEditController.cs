using Microsoft.AspNetCore.Mvc;
using StarTrack.Core.Models;
using System.Data.Entity;

namespace StarTrack.Web.Controllers
{
    public class NewsEditController : Controller
    {
        public ActionResult create()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult create(News model)
        {

            using (var context = new Database())
            {
                context.News.Add(model);

                context.SaveChanges();
            }
            string message = "Created the record successfully";

            ViewBag.Message = message;

            return View();

        }*/
    }
}
