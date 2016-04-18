using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    internal interface IRequestRepository
    {
        List<RequestForm> GetAll();

        RequestForm GetById(int id);

        void Add(RequestForm model);

        void Update(int id, RequestForm model);

        void Delete(int id);
    }
}