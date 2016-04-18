using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    internal interface IVehicleRepository
    {
        List<Vehicle> GetAll();

        Vehicle GetById(int id);

        Vehicle AddVehicle(Vehicle model);

        void Update(int id, Vehicle model);

        void Delete(int id);
    }
}