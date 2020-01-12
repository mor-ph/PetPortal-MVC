using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using DA.Entities;
using DA.Repositories;
using MVC_proj.Filters;
using MVC_proj.Models;
using MVC_proj.ViewModels.Shared;
using MVC_proj.ViewModels.Users;

namespace UsersManager.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new FilterVM();
            Expression<Func<User, bool>> filter = model.Filter.GenerateFilter();

            UsersRepository repo = new UsersRepository();
            model.Items = repo.GetAll(filter, model.Pager.Page, model.Pager.ItemsPerPage);
            model.Pager.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)(model.Pager.ItemsPerPage));
            
            return View(model);
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult View_Profile(int? id)
        {
            User item = null;

            UsersRepository repo = new UsersRepository();
            item = repo.GetById(AuthenticationManager.LoggedUser.Id);
            View_ProfileVM model = new View_ProfileVM(item);

            return View(model);
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            User item = null;

            UsersRepository repo = new UsersRepository();
            item = id == null ? new User() : repo.GetById(id.Value);

            EditVM model = new EditVM(item);
            if(AuthenticationManager.LoggedUser.Id != 1 &&
                AuthenticationManager.LoggedUser.Id != model.Id)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UsersRepository repo = new UsersRepository();
            User item = new User();
            model.PopulateEntity(item);

            repo.Save(item);

            return RedirectToAction("Index", "Users");
        }


        [HttpGet]
        public ActionResult Register()
        {
            User item = null;
            UsersRepository repo = new UsersRepository();
            item = new User();
            EditVM model = new EditVM(item);
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UsersRepository repo = new UsersRepository();
            User item = new User();
            model.PopulateEntity(item);

            repo.Save(item);

            return RedirectToAction("Index", "Users");
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            UsersRepository repo = new UsersRepository();
            User item = repo.GetById(id);
            if (AuthenticationManager.LoggedUser.Id != 1 &&
                AuthenticationManager.LoggedUser.Id != item.Id)
            {
                return RedirectToAction("Login", "Home");
            }
            else
                repo.Delete(item);

            return RedirectToAction("Index", "Users");
        }
    }
}