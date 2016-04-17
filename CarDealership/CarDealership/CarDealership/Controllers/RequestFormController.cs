using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Data;
using CarDealership.Models;

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

        public ActionResult NewForm()
        {
            return View("NewForm",new RequestForm());
        }

        [HttpPost]
        public ActionResult NewForm(RequestForm newFrom)
        {
            var repo = new RequestRepository();
            repo.Add(newFrom);

            return RedirectToAction("List");
        }

        public ActionResult DeleteForm(int id)
        {
            var repo = new RequestRepository();
            var form = repo.GetById(id);
            return View(form);
        }
        
        [HttpPost]
        public ActionResult DeleteForm(RequestForm form)
        {
            var repo = new RequestRepository();
            repo.Delete(form.VehicleId);

            return RedirectToAction("List");
        }

        public ActionResult UpdateForm(int id)
        {
            var repo = new RequestRepository();
            var form = repo.GetById(id);
            return View(form);
        }
        
        [HttpPost]
        public ActionResult UpdateForm(RequestForm form)
        {
            var repo = new RequestRepository();
            repo.Update(form);

            return RedirectToAction("List");
        }
    }
}