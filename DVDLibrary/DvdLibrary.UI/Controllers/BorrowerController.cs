using DvdLibrary.Data;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DvdLibrary.UI.Controllers
{
    public class BorrowerController : Controller
    {
        // GET: Borrower
        public ActionResult Borrower()
        {
            List<Borrower> BorrowerList = new List<Borrower>();
            var repo = new BorrowerRepository();
            BorrowerList = repo.GetAll();

            return View(BorrowerList);
        }

        public ActionResult BorrowHistory(int id)
        {
        }
    }
}