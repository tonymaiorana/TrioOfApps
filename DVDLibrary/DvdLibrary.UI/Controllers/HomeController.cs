using DvdLibrary.BLL;
using DvdLibrary.Data;
using DvdLibrary.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

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

        public ActionResult Register()
        {
            List<Borrower> BorrowerList = new List<Borrower>();
            var repo = new BorrowerRepository();
            BorrowerList = repo.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Register(Borrower newBorrower)
        {
            if (ModelState.IsValid)
            {
                var repo = new BorrowerRepository();
                repo.AddBorrower(newBorrower);
                return View("RegisterSuccess");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                if (borrower.IsValid(borrower.LastName, borrower.PhoneNumber))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Borrower()
        {
            List<Borrower> BorrowerList = new List<Borrower>();
            var repo = new BorrowerRepository();
            BorrowerList = repo.GetAll();

            return View(BorrowerList);
        }

        public ActionResult EditBorrower(int id)
        {
            var repo = new BorrowerRepository();
            var borrowerToEdit = repo.GetById(id);
            return View(borrowerToEdit);
        }

        [HttpPost]
        public ActionResult EditBorrower(Borrower editBorrower)
        {
            var repo = new BorrowerRepository();
            repo.Update(editBorrower.BorrowerId, editBorrower);
            return RedirectToAction("Borrower");
        }

        public ActionResult DeleteBorrower(int id)
        {
            var repo = new BorrowerRepository();
            repo.Delete(id);
            return RedirectToAction("Borrower");
        }
    }
}