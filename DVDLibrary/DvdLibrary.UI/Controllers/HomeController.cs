using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using DvdLibrary.Models;
using DvdLibrary.UI.Models;
=======
using DvdLibrary.BLL;
>>>>>>> 764c7408fc326529e61ad951f950396e33352328

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

<<<<<<< HEAD
        public ActionResult AddDvd()
        {
            return View(new AddDvdVM(new List<MPAARating>().));
=======
        // Delete DVD by ID
        public ActionResult DeleteDvd(int DvdID)
        {
            var ops = new DvdOperations();
            ops.DeleteDvd(DvdID);

            return RedirectToAction("Index");
>>>>>>> 764c7408fc326529e61ad951f950396e33352328
        }
    }
}