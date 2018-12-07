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
    public class TrailController : Controller
    {
        // GET: Trail
        public ActionResult Index()
        {
            var service = CreateTrailService();
            var model = service.GetTrails();
            return View(model);
        }
        //Add method here VVVV
        // GET
        public ActionResult Create()
        {
            var service = CreateEquipmentService();
            var equipment = service.GetEquipment();
            ViewBag.EquipmentId = new SelectList(equipment, "EquipmentId", "EquipmentName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrailCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTrailService();

            if (service.CreateTrail(model))
            {
                TempData["SaveResult"] = "Your trail was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Trail could not be created.");

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateTrailService();
            var detail = service.GetTrailById(id);
            var model =
                new TrailEdit
                {
                    TrailId = detail.TrailId,
                    TrailName = detail.TrailName,
                    Description = detail.Description,
                    EquipmentId = detail.EquipmentId,
                    TrailRank = detail.TrailRank,
                    Location = detail.Location,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrailEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TrailId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateTrailService();

            if (service.UpdateTrail(model))
            {
                TempData["SaveResult"] = "Your trail was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your trail could not be updated.");

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrailService();
            var model = svc.GetTrailById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTrailService();
            service.DeleteTrail(id);
            TempData["SaveResult"] = "Your trail was deleted";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateTrailService();
            var model = svc.GetTrailById(id);


            return View(model);
        }
        private TrailService CreateTrailService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrailService(userId);
            return service;
        }
        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;
        }
    }
}