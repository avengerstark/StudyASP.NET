using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.Models;
using AutoMapper.Context;
using AutoMapper;

namespace AutoMapper.Controllers
{
    public class HomeController : Controller
    {
        IRepository<User> repo;
        public HomeController()
        {
            repo = new UserRepository();
        }
        public ActionResult Index()
        {
            // Настройка AutoMapper
            // В данном случае объект User будет сопоставляться с объектом IndexUserViewModel.
            // В данном случае большое значение имеет порядок: так как в методе Index получаем
            // из бд объекты User и из них создаем объекты IndexUserViewModel,
            // то первым в Mapper.CreateMap<User,IndexUserViewModel> идет User. 
            Mapper.CreateMap<User, IndexUserViewModel>();
            // сопоставление
            var users =
                Mapper.Map<IEnumerable<User>, List<IndexUserViewModel>>(repo.GetAll());
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Настройка AutoMapper
                // Метод ForMember() предназначен для проецирования отдельных
                // свойств одного класса на свойства другого класса
                Mapper.CreateMap<CreateUserViewModel, User>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName))
                    .ForMember("Email", opt => opt.MapFrom(src => src.Login));
                // Выполняем сопоставление
                User user = Mapper.Map<CreateUserViewModel, User>(model);
                repo.Create(user);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            // Настройка AutoMapper
            Mapper.CreateMap<User, EditUserViewModel>()
                .ForMember("Login", opt => opt.MapFrom(src => src.Email));
            // Выполняем сопоставление
            EditUserViewModel user = Mapper.Map<User, EditUserViewModel>(repo.Get(id.Value));
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Настройка AutoMapper
                Mapper.CreateMap<EditUserViewModel, User>()
                    .ForMember("Email", opt => opt.MapFrom(src => src.Login));
                // Выполняем сопоставление
                User user = Mapper.Map<EditUserViewModel, User>(model);
                repo.Update(user);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}