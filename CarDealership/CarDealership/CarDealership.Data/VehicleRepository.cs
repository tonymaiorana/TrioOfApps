using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    internal class VehicleRepository : IVehicleRepository
    {
        private List<Vehicle> Cars = new List<Vehicle>();

        private string constr;

        public VehicleRepository()
        {
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public List<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Vehicle AddBorrower(Vehicle model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Vehicle model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}