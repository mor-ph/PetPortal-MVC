using DA.Entities;
using DA.Repositories;
using MVC_proj.Filters;
using MVC_proj.Models;
using MVC_proj.ViewModels.Vaccines;
using System.Web.Mvc;

namespace MVC_proj.Controllers
{
    
    public class VaccineController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            VaccinesRepository repo = new VaccinesRepository();
            model.Items = repo.GetAllItems();
            
            return View(model);
        }

        [HttpGet]
        [AuthenticationFilter]
        public ActionResult Edit(int? id)
        {
            Vaccine item = null;

            VaccinesRepository repo = new VaccinesRepository();
            item = id == null ? new Vaccine() : repo.GetById(id.Value);

            EditVM model = new EditVM(item);
            if (AuthenticationManager.LoggedUser.Id != 1)
                return RedirectToAction("Login", "Home");
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            VaccinesRepository repo = new VaccinesRepository();
            Vaccine item = new Vaccine();
            model.PopulateEntity(item);

            repo.Save(item);

            return RedirectToAction("Index", "Vaccine");
        }
        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            VaccinesRepository repo = new VaccinesRepository();
            Vaccine item = repo.GetById(id);

            if (AuthenticationManager.LoggedUser.Id != 1)
                return RedirectToAction("Login", "Home");
            else
                repo.Delete(item);

            return RedirectToAction("Index", "Vaccine");
        }
    }
}