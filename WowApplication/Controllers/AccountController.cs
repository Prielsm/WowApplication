using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WowApplication.Infra;
using WowApplication.Models;
using WowApplication.Repositories;

namespace WowApplication.Controllers
{
    public class AccountController : Controller
    {
        DataContext dtx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Donjons", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            return View(lvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                MembreModel um = dtx.UserAuth(lm);

                if (um == null)
                {
                    ViewBag.Error = "Erreur login ou password";
                    return View();

                }
                else
                {
                    SessionUtils.IsLogged = true;
                    SessionUtils.ConnectedUser = um;

                    return RedirectToAction("Donjons", "Home");
                }
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MembreModel um)
        {
            if (ModelState.IsValid)
            {
                if (dtx.CreateMembre(um))
                {
                    SessionUtils.IsLogged = true;
                    SessionUtils.ConnectedUser = um;
                    return RedirectToAction("Donjons", "Home");
                }
                else
                {
                    ViewBag.Error = "Erreur Login/Password";
                    return View(um);
                }
            }
            else
            {
                return View(um);
            }
        }
    }
}