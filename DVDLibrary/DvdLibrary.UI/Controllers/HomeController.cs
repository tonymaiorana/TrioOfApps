﻿using DvdLibrary.BLL;
using DvdLibrary.Data;
using DvdLibrary.Models;
using DvdLibrary.UI.Models;
using Microsoft.Ajax.Utilities;
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

        public ActionResult List(int id = 0)
        {
            var repo = new DvdRepository();
            var brepo = new BorrowerRepository();
            var vm = new ListDvdVM();
            vm.Dvds = repo.GetAllDvds();
            if (id != 0)
            {
                vm.currentBorrower = brepo.GetById(id);
            }
            return View(vm);
        }

        [HttpPost]
        public ActionResult BorrowDvd(int id)
        {
            return View();
        }

        public ActionResult AddDvd()
        {
            return View(new DvdVM( new List<Director>()));
        }

        [HttpPost]
        public ActionResult AddDVD(Dvd newDvd)
        {
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
        public ActionResult Login(string LastName, string PhoneNumber)
        {
            List<Borrower> BorrowerList = new List<Borrower>();
            var repo = new BorrowerRepository();
            var borrower = repo.GetByLastNamePhone(LastName, PhoneNumber);
            BorrowerList = repo.GetAll();
            if (borrower.IsActive)
            {
                int id = borrower.BorrowerId;
                return RedirectToAction("List", id);
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

        public ActionResult BorrowList(int id)
        {
            var repo = new BorrowInfoRepository();
            repo.GetById(id);
            var vm = new BorrowInfoVM();
            return View(vm);
        }

        public ActionResult DeactivateBorrow(int id)
        {
            var repo = new BorrowInfoRepository();
            repo.Delete(id);
            return RedirectToAction("BorrowList");
        }
    }
}