using CarDealership.Data;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class RequestFormController : Controller
    {
        // GET: RequestForm
        public ActionResult List()
        {
            var repo = new RequestRepository();
            var allForms = repo.GetAll();
            return View(allForms);
        }

        public ActionResult Details(int id)
        {
            var repo = new RequestRepository();
            var form = repo.GetById(id);
            return View(form);
        }

        public ActionResult NewForm(int id)
        {
            var newForm = new RequestForm();
            newForm.VehicleId = id;
            return View(newForm);
        }

        [HttpPost]
        public ActionResult NewForm(RequestForm newForm)
        {
            var repo = new RequestRepository();
            newForm.RequestFormStatus = RequestFormStatus.New;
            newForm.LastContacted = null;
            repo.Add(newForm);

            return RedirectToAction("ListCars", "Home");
        }

        public ActionResult DeleteForm(int id)
        {
            var repo = new RequestRepository();
            var form = repo.GetById(id);
            return View(form);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteForm(RequestForm form)
        {
            var repo = new RequestRepository();
            repo.Delete(form.RequestFormId);

            return RedirectToAction("List");
        }

        public ActionResult UpdateForm(int id)
        {
            var repo = new RequestRepository();
            var form = repo.GetById(id);
            return View(form);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateForm(RequestForm form)
        {
            var repo = new RequestRepository();
            repo.Update(form.RequestFormId, form);
            return RedirectToAction("List");
        }
    }
}