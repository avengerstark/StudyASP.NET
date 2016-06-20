using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IoC.Context;

namespace IoC.Controllers
{
    public class HomeController : Controller
    {
        // Контроллер содержит ссылку на BookRepository и в данном случае он зависит от BookRepository.
        // А сам объект BookRepository является зависимостью.
        //BookRepository repo;
        //public HomeController()
        //{
        //    repo = new BookRepository();
        //}


        // И теперь мы можем избавить контроллер от жесткой зависимости от компонента


        IRepository repo;
        public HomeController(IRepository r)
        {
            repo = r;
        }

        // Теперь контроллер ничего не знает и не зависит от конкретной реализации репозитория.

        public ActionResult Index()
        {
            return View(repo.List());
        }
    }
}