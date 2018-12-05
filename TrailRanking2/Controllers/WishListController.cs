using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailRanking.Models;
using TrailRanking.Services;

namespace TrailRanking2.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WishListService(userId);
            var model = service.GetWishLists();

            return View(model);
        }
        //Add method here VVVV
        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WishListCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateWishListService();

            if (service.CreateWishList(model))
            {
                TempData["SaveResult"] = "Your wishList was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "WishList could not be created.");

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateWishListService();
            var detail = service.GetWishListById(id);
            var model =
                new WishListEdit
                {
                    WishListId = detail.WishListId,
                    Trail = detail.Trail,
                    Location = detail.Location
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WishListEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.WishListId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateWishListService();

            if (service.UpdateWishList(model))
            {
                TempData["SaveResult"] = "Your wishList was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your wishList could not be updated.");

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWishListService();
            var model = svc.GetWishListById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWishListService();
            service.DeleteWishList(id);
            TempData["SaveResult"] = "Your wishList was deleted";
            return RedirectToAction("Index");
        }
        private WishListService NewMethod()
        {
            WishListService service = CreateWishListService();
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateWishListService();
            var model = svc.GetWishListById(id);


            return View(model);
        }
        private WishListService CreateWishListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WishListService(userId);
            return service;
        }
    }
}