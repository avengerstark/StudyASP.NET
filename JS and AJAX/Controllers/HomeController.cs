using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JS_and_AJAX.Models;

namespace JS_and_AJAX.Controllers
{
    public class HomeController : Controller
    {
        private BookContext _db = new BookContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult BookSearch(string name)
        {
            var allBooks = _db.Books.Where(a => a.Author.Contains(name)).ToList();
            if (allBooks.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allBooks);
           
        }

    }
}