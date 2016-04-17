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
            var repo = new CarDealershipRepository();
            var allForms = repo.GetAllRequestForms();
            return View(allForms);
        }

        public ActionResult Details(int id)
        {
            var repo = new CarDealershipRepository();
            var form = repo.GetRequestFormById(id);
            return View(form);
        }

        public ActionResult NewForm()
        {
            return View("NewForm",new RequestForm());
        }

        [HttpPost]
        public ActionResult NewForm(RequestForm newFrom)
        {
            var repo = new CarDealershipRepository();
            repo.Add(newFrom);

            return RedirectToAction("List");
        }

        public ActionResult DeleteForm(int id)
        {
            var repo = new CarDealershipRepository();
            var form = repo.GetRequestFormById(id);
            return View(form);
        }
        
        [HttpPost]
        public ActionResult DeleteForm(RequestForm form)
        {
            var repo = new CarDealershipRepository();
            repo.Delete(form.VehicleId);

            return RedirectToAction("List");
        }

        public ActionResult EditForm(int id)
        {
            var repo = new CarDealershipRepository();
            var form = repo.GetRequestFormById(id);
            return View(form);
        }
        
        [HttpPost]
        public ActionResult EditForm(RequestForm form)
        {
            var repo = new CarDealershipRepository();
            repo.Edit(form);

            return RedirectToAction("List");
        }
    }
}