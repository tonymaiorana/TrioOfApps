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
            throw new NotImplementedException();
        }

        public RequestForm GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RequestForm AddBorrower(RequestForm model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, RequestForm model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}