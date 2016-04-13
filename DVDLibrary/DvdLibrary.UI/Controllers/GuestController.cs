using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DvdLibrary.UI.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult GuestList()
        {
            return View();
        }
    }
}