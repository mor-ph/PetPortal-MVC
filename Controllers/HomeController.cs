using MVC_proj.Models;
using MVC_proj.ViewModels.Home;
using System.Web.Mvc;

namespace UsersManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (AuthenticationManager.LoggedUser != null)
                Logout();
            if (ModelState.IsValid)
            {
                AuthenticationManager.Authenticate(model.Username, model.Password);

                if (AuthenticationManager.LoggedUser == null)
                    ModelState.AddModelError("authenticationFailed", "Wrong username or password!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Users");
        }

        public ActionResult Logout()
        {
            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }
    }
}