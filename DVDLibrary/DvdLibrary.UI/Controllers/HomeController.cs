using DvdLibrary.BLL;
using DvdLibrary.Models;
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

        public ActionResult AddDvd()
        {
            var mpaaRating = typeof (MPAARating);
           var vm = new AddDvdVM(new List<Dvd>());
            return View(
                );
             return View("AddDvd");
        }
       
        // Delete DVD by ID
        public ActionResult DeleteDvd(int DvdID)
        {
            var ops = new DvdOperations();
            var dvd = ops.GetDvdById(DvdID);

            return View(dvd);
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