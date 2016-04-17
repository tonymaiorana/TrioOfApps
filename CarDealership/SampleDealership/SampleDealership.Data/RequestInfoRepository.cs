using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDealership.Models;

namespace SampleDealership.Data
{
    public class RequestInfoRepository
    {
        private static List<RequestInformation> _requestForms = new List<RequestInformation>();

        public RequestInfoRepository()
        {
            if (!_requestForms.Any())
            {
                _requestForms.AddRange(new List<RequestInformation>()
                {
                    new RequestInformation()
                    {
                        VehicleId = 1,
                        Name = "Victor Pudelski",
                        EmailAddress = "victor@swcguild.com",
                        PhoneNumber = "123-4567",
                        BestTimeToCall = DateTime.Today,
                        PreferredContactMethod = "phone",
                        TimeframeToPurchase = 12,
                        AdditionalInformation = "Cash payment",
                        LastContactDate = DateTime.Now,
                        StatusOfRequest = "First call"
                    },

                    new RequestInformation()
                    {
                        VehicleId = 2,
                        Name = "Kirk Brown",
                        EmailAddress = "victor@swcguild.com",
                        PhoneNumber = "123-4567",
                        BestTimeToCall = DateTime.Today,
                        PreferredContactMethod = "phone",
                        TimeframeToPurchase = 12,
                        AdditionalInformation = "Cash payment",
                        LastContactDate = DateTime.Now,
                        StatusOfRequest = "First call"
                    },

                     new RequestInformation()
                    {
                        VehicleId = 3,
                        Name = "Kaz Nishimoto",
                        EmailAddress = "victor@swcguild.com",
                        PhoneNumber = "123-4567",
                        BestTimeToCall = DateTime.Today,
                        PreferredContactMethod = "phone",
                        TimeframeToPurchase = 12,
                        AdditionalInformation = "Cash payment",
                        LastContactDate = DateTime.Now,
                        StatusOfRequest = "First call"
                    }
                });
            }
        }

        public List<RequestInformation> GetAllRequestForms()
        {
            return _requestForms;
        }

        public RequestInformation GetById(int id)
        {
            return _requestForms.FirstOrDefault(f => f.VehicleId == id);
        }

        public void Add(RequestInformation newForm)
        {
            newForm.VehicleId = (_requestForms.Any()) ? _requestForms.Max(f => f.VehicleId) + 1 : 1;

            _requestForms.Add(newForm);
        }

        public void Delete(int id)
        {
            _requestForms.RemoveAll(f => f.VehicleId == id);
        }

        public void Edit(RequestInformation form)
        {
            Delete(form.VehicleId);
            _requestForms.Add(form);
        }
    }
}
