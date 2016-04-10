using DvdLibrary.BLL;
using DvdLibrary.Models;
using DvdLibrary.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DvdLibrary.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddDvd()
        {
            return View(
                );
        }

        //private needs to private create GetDvdById

        //  private Delete DVD private by ID

        public ActionResult DeleteDvd(int DvdID)

        {
            var ops = new DvdOperations();
            // var dvd = ops.GetDvdById(DvdID);

            return View();
        }

        [HttpPost]
        public ActionResult DeleteDvd(Dvd dvd)
        {
            var ops = new DvdOperations();
            ops.DeleteDvd(dvd.DvdId);

            return RedirectToAction("Index");
        }
    }
}