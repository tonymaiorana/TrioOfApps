using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public class RequestRepository : IRequestRepository
    {
        private List<RequestForm> Requests = new List<RequestForm>();

        private string constr;

        public RequestRepository()
        {
            constr = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
        }

        public List<RequestForm> GetAll()
        {
            return Requests;
        }

        public RequestForm GetById(int id)
        {
            return Requests.FirstOrDefault(f => f.VehicleId == id);
        }

        public void Add(RequestForm form)
        {
            form.VehicleId = (Requests.Any()) ? Requests.Max(f => f.VehicleId) + 1 : 1;

            Requests.Add(form);
        }

        public void Update(RequestForm form)
        {
            Delete(form.VehicleId);
            Requests.Add(form);
        }

        public void Delete(int id)
        {
            Requests.RemoveAll(f => f.VehicleId == id);
        }
    }
}