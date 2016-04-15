using DvdLibrary.BLL;
using DvdLibrary.Data;
using DvdLibrary.Models;
using DvdLibrary.UI.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DvdLibrary.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int id = 0)
        {
            var repo = new DvdRepository();
            var brepo = new BorrowerRepository();
            var vm = new ListDvdVM();
            vm.Dvds = repo.GetAllDvds();
            vm.currentBorrower = brepo.GetById(id);

            return View(vm);
        }

        public ActionResult DvdDetails(int dvdId)
        {
            var ops = new DvdOperations();
            Dvd dvd = new Dvd();
            dvd = ops.GetDvdById(dvdId);

            return View(dvd);
        }

        [HttpPost]
        public ActionResult BorrowDvd(BorrowDvdVM borrowDvdVm)
        {
            var repo = new BorrowInfoRepository();
            var brepo = new BorrowerRepository();
            var borrowInfo = new BorrowInfo();
            borrowInfo.DvdId = borrowDvdVm.DvdID;
            borrowInfo.Borrower = brepo.GetById(borrowDvdVm.BorrowerID);
            borrowInfo.DateBorrowed = DateTime.Today;
            borrowInfo.IsActive = true;
            repo.AddBorrowInfo(borrowInfo);
            return RedirectToAction("List", new { id = borrowDvdVm.BorrowerID });
        }

        public ActionResult AddDvd()
        {
            var repo = new DvdRepository();
            var vm = new DvdVM(repo.GetAllDirectors());
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddDVD(DvdVM newDvdVm)
        {
            Dvd newDvd = newDvdVm.Dvd;
            var repo = new DvdRepository();
            repo.AddDvd(newDvd);
            return RedirectToAction("List");
        }

        public ActionResult DeleteDvd(int dvdId)
        {
            var ops = new DvdOperations();
            var dvd = ops.GetDvdById(dvdId);

            return View(dvd);
        }

        [HttpPost]
        public ActionResult DeleteDvd(Dvd dvd)
        {
            var ops = new DvdOperations();
            ops.DeleteDvd(dvd.DvdId);

            return RedirectToAction("List");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Borrower newBorrower)
        {
            if (ModelState.IsValid)
            {
                var repo = new BorrowerRepository();
                repo.AddBorrower(newBorrower);
                return View("RegisterSuccess", newBorrower);
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string LastName, string PhoneNumber)
        {
            var repo = new BorrowerRepository();
            var borrower = repo.GetByLastNamePhone(LastName.ToUpper(), PhoneNumber);

            if (borrower != null)
            {
                borrower.IsActive = true;
                int id = borrower.BorrowerId;
                return RedirectToAction("List", new { id = id });
            }
            else
            {
                return RedirectToAction("Register");
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

        //list of all borrowinfo
        public ActionResult BorrowInfo()
        {
            List<BorrowInfo> BorrowList = new List<BorrowInfo>();
            var repo = new BorrowInfoRepository();
            BorrowList = repo.GetAll();

            return View(BorrowList);
        }

        //list of borrow info per borrower
        public ActionResult BorrowList(int id)
        {
            List<BorrowInfo> BorrowList = new List<BorrowInfo>();
            var repo = new BorrowInfoRepository();
            BorrowList = repo.GetByBorrowerId(id);

            return View(BorrowList);
        }

        public ActionResult DeactivateBorrow(int id)
        {
            var repo = new BorrowInfoRepository();
            repo.Delete(id);
            var currentBorrowInfo = repo.GetById(id);
            var borrowerID = currentBorrowInfo.BorrowerID;

            return RedirectToAction("BorrowList", new { id = borrowerID });
        }

        [HttpPost]
        public ActionResult SearchDvdByTitle(string title)
        {
            var ops = new DvdOperations();
            var dvd = ops.GetDvdByTitle(title);
            if (dvd.Title == null)
            {
                //ViewBag.Message = "Error. DVD does not exist!";
                return RedirectToAction("List");
            }
            else
            {
                return View("DvdDetails", dvd);
            }
        }
    }
}