using CarDealership.Data;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ListCars()
        {
            var repo = new VehicleRepository();
            var cars = repo.GetAll();
            return View(cars);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CarDetails(int vehicleId)
        {
            var repo = new VehicleRepository();
            var car = repo.GetById(vehicleId);
            return View(car);
        }

        public ActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCar(Vehicle vehicle)
        {
            var repo = new VehicleRepository();
            repo.AddVehicle(vehicle);
            return RedirectToAction("ListCars");
        }

        public ActionResult EditCar(int id)
        {
            var repo = new VehicleRepository();
            var carToEdit = repo.GetById(id);
            return View(carToEdit);
        }

        public ActionResult DeleteCar(int id)
        {
            var repo = new VehicleRepository();
            repo.Delete(id);
            return RedirectToAction("ListCars");
        }
    }
}