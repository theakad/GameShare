using System.Net;
using System.Web.Mvc;
using GameShare.Entity.Entities;
using GameShare.Business.Interface;
using GameShare.Models;
using System.Collections.Generic;

namespace GameShare.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IFriendBusiness _friendBusiness;

        public FriendsController(IFriendBusiness friendBusiness)
        {
            _friendBusiness = friendBusiness;
        }

        public ActionResult Index()
        {
            var result = _friendBusiness.List();
            List<FriendViewModel> vm = new List<FriendViewModel>();
            foreach (var item in result)
            {
                var x = new FriendViewModel();
                x = item;
                vm.Add(x);
            }
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendViewModel friend = _friendBusiness.GetBy(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _friendBusiness.Create(friend);
                return RedirectToAction("Index");
            }

            return View(friend);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendViewModel friend = _friendBusiness.GetBy(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _friendBusiness.Edit(friend);
                return RedirectToAction("Index");
            }
            return View(friend);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendViewModel friend = _friendBusiness.GetBy(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _friendBusiness.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _friendBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
