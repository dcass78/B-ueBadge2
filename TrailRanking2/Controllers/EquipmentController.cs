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
    public class EquipmentController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateEquipmentService();
            var model = service.GetEquipment();

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
        public ActionResult Create(EquipmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEquipmentService();

            if (service.CreateEquipment(model))
            {
                TempData["SaveResult"] = "Your Equipment was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Equipment could not be created.");

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateEquipmentService();
            var detail = service.GetEquipmentById(id);
            var model =
                new EquipmentEdit
                {
                    EquipmentId = detail.EquipmentId,
                    EquipmentName = detail.EquipmentName,
                    EquipmentUse = detail.EquipmentUse,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EquipmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EquipmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateEquipmentService();

            if (service.UpdateEquipment(model))
            {
                TempData["SaveResult"] = "Your Equipment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Equipment could not be updated.");

            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEquipmentService();
            var model = svc.GetEquipmentById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEquipment(int id)
        {
            var service = CreateEquipmentService();
            service.DeleteEquipment(id);
            TempData["SaveResult"] = "Your Equipment was deleted";
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateEquipmentService();
            var model = svc.GetEquipmentById(id);


            return View(model);
        }
        private EquipmentService CreateEquipmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EquipmentService(userId);
            return service;
        }
    }
}