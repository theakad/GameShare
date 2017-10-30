using GameShare.Business.Interface;
using GameShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameShare.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILoginBusiness _loginBusiness;

        public HomeController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] HomeViewModel homeViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_loginBusiness.CheckAuth(homeViewModel))
                {
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "Usuário ou senha incorretos");
            }

            return View();
        }
    }
}