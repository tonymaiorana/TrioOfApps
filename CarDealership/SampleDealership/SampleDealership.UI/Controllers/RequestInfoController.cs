using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleDealership.Data;
using SampleDealership.Models;

namespace SampleDealership.UI.Controllers
{
    public class RequestInfoController : Controller
    {
        // GET: RequestInfo
        public ActionResult List()
        {
            var repo = new RequestInfoRepository();
            var allforms = repo.GetAllRequestForms();
            return View(allforms);
        }

        public ActionResult Details(int id)
        {
            var repo = new RequestInfoRepository();
            var form = repo.GetById(id);
            return View(form);
        }

        public ActionResult NewForm()
        {
            return View("NewForm",new RequestInformation());
        }

        [HttpPost]
        public ActionResult NewForm(RequestInformation newFrom)
        {
            var repo = new RequestInfoRepository();
            repo.Add(newFrom);

            return RedirectToAction("List");
        }

        public ActionResult DeleteForm(int id)
        {
            var repo = new RequestInfoRepository();
            var form = repo.GetById(id);
            return View(form);
        }
        
        [HttpPost]
        public ActionResult DeleteForm(RequestInformation form)
        {
            var repo = new RequestInfoRepository();
            repo.Delete(form.VehicleId);

            return RedirectToAction("List");
        }

        public ActionResult EditForm(int id)
        {
            var repo = new RequestInfoRepository();
            var form = repo.GetById(id);
            return View(form);
        }
        
        [HttpPost]
        public ActionResult EditForm(RequestInformation form)
        {
            var repo = new RequestInfoRepository();
            repo.Edit(form);

            return RedirectToAction("List");
        }
    }
}