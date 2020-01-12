using DA.Entities;
using DA.Repositories;
using MVC_proj.Filters;
using MVC_proj.Models;
using MVC_proj.ViewModels.Pets;
using MVC_proj.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MVC_proj.Controllers
{
    public class PetController : Controller
    {
        public ActionResult Index(IndexVM model)
        {
            PetsRepository repo = new PetsRepository();
            model.Items = repo.GetAllItems();
            return View(model);
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Pet item = null;

            PetsRepository repo = new PetsRepository();
            VaccinesRepository v_repo = new VaccinesRepository();

            item = id == null ? new Pet() : repo.GetById(id.Value);

            EditVM model = new EditVM(item);

            List<Vaccine> available = new List<Vaccine>();
            List<CheckBoxItem> selected = new List<CheckBoxItem>();
            
            available = v_repo.GetAllItems();

            foreach(var v in available)
            {
                selected.Add(new CheckBoxItem()
                {
                    ID = v.Id,
                    Display = v.Name,
                    IsChecked = item.ContainsV(v)
                });
            }
            foreach(var v in selected)
            {
                    model.Selected.Add(v);
            }

            if (AuthenticationManager.LoggedUser.Id != 1 &&
                AuthenticationManager.LoggedUser.Id != model.User_Id)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UnitOfWork uow = new UnitOfWork();
            PetsRepository Repo = new PetsRepository(uow);
            VaccinesRepository V_repo = new VaccinesRepository(uow);

            Pet item = new Pet();
            Vaccine vac = new Vaccine();
            item.Vaccines = new List<Vaccine>();
            model.PopulateEntity(item);

            item.Vaccines.Clear();

            foreach (var v in model.Selected)
            {
                vac = V_repo.GetById(v.ID);
                if (v.IsChecked)
                {
                    vac.Pet.Remove(item);

                    item.Vaccines.Add(vac);
                    vac.Pet.Add(item);
                }
            }
            //List<Vaccine> vacs = new List<Vaccine>();

            /* foreach (var v in model.Selected)
             {
                 if (v.IsChecked)
                 {
                     Vaccine sel = new Vaccine();
                     sel = v_repo.GetById(v.ID);
                     vacs.Add(sel);
                 }
             }
             foreach (var v in vacs)
             {
                 v_repo.Save(v);
             }*/

            Repo.Save(item);

            uow.Commit();
            //return View(model);
            return RedirectToAction("Index", "Pet");
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            PetsRepository repo = new PetsRepository();
            Pet item = repo.GetById(id);

            if (AuthenticationManager.LoggedUser.Id != 1 &&
                AuthenticationManager.LoggedUser.Id != item.UserId)
            {
                RedirectToAction("Login", "Home");
            }
            else
              repo.Delete(item);

            return RedirectToAction("Index", "Pet");
        }
    }
}