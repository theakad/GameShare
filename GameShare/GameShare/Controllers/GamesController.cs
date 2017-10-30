using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GameShare.Business.Interface;
using GameShare.Entity.Entities;
using GameShare.Models;
using System.Collections.Generic;

namespace GameShare.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameBusiness _gameBusiness;
        public GamesController(IGameBusiness gameBusiness)
        {
            _gameBusiness = gameBusiness;
        }

        // GET: Games
        public ActionResult Index()
        {
            var result = _gameBusiness.List();
            List<GameViewModel> vm = new List<GameViewModel>();
            foreach (var item in result)
            {
                var x = new GameViewModel();
                x = item;
                vm.Add(x);
            }
            return View(vm);
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameViewModel game = _gameBusiness.GetBy(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.FriendId = new SelectList(_gameBusiness.GetFriendsOnGame(), "Id", "Name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Style,Description,Image,IsAvailable,FriendId")] Game game)
        {
            if (ModelState.IsValid)
            {
                _gameBusiness.Create(game);
                return RedirectToAction("Index");
            }

            ViewBag.FriendId = new SelectList(_gameBusiness.GetFriendsOnGame(), "Id", "Name", game.FriendId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameViewModel game = _gameBusiness.GetBy(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.FriendId = new SelectList(_gameBusiness.GetFriendsOnGame(), "Id", "Name", game.FriendId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Style,Description,Image,IsAvailable,FriendId")] Game game)
        {
            if (ModelState.IsValid)
            {
                _gameBusiness.Edit(game);
                return RedirectToAction("Index");
            }
            ViewBag.FriendId = new SelectList(_gameBusiness.GetFriendsOnGame(), "Id", "Name", game.FriendId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameViewModel game = _gameBusiness.GetBy(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _gameBusiness.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _gameBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
