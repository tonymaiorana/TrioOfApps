using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Data
{
    public class CarDealershipRepository
    {
        private static List<RequestForm> _requestForms = new List<RequestForm>();

        public CarDealershipRepository()
        {
            if (!_requestForms.Any())
            {
                _requestForms.AddRange(new List<RequestForm>()
                {
                    new RequestForm()
                    {
                        VehicleId = 1,
                        FirstName = "Victor",
                        LastName = "Pudelski",
                        EmailAddress = "victor@swcguild.com",
                        PhoneNumber = "123-4567",
                        BestTimeToCall = "7 pm",
                        PreferedContactMethod = PreferedContactMethod.PhoneCall,
                        DateNeedToPurchaseBy = DateTime.Now,
                        AdditionalInfo = "Cash payment",
                        LastContacted = DateTime.Now,
                        RequestFormStatus = RequestFormStatus.AwaitingReply,
                        UserAccountId = 1
                    },

                    new RequestForm()
                    {
                        VehicleId = 2,
                        FirstName = "Kaz",
                        LastName = "Tanaka",
                        EmailAddress = "victor@swcguild.com",
                        PhoneNumber = "123-9876",
                        BestTimeToCall = "7 pm",
                        PreferedContactMethod = PreferedContactMethod.PhoneCall,
                        DateNeedToPurchaseBy = DateTime.Now,
                        AdditionalInfo = "Cash payment",
                        LastContacted = DateTime.Now,
                        RequestFormStatus = RequestFormStatus.AwaitingReply,
                        UserAccountId = 2
                    },

                    new RequestForm()
                    {
                        VehicleId = 1,
                        FirstName = "Kirk",
                        LastName = "Brown",
                        EmailAddress = "victor@swcguild.com",
                        PhoneNumber = "456-4567",
                        BestTimeToCall = "7 pm",
                        PreferedContactMethod = PreferedContactMethod.PhoneCall,
                        DateNeedToPurchaseBy = DateTime.Now,
                        AdditionalInfo = "Cash payment",
                        LastContacted = DateTime.Now,
                        RequestFormStatus = RequestFormStatus.AwaitingReply,
                        UserAccountId = 3
                    }
                });
            }
        }


        public List<RequestForm> GetAllRequestForms()
        {
            return _requestForms;
        }

        public RequestForm GetRequestFormById(int id)
        {
            return _requestForms.FirstOrDefault(f => f.VehicleId == id);
        }

        public void Add(RequestForm newForm)
        {
            newForm.VehicleId = (_requestForms.Any()) ? _requestForms.Max(f => f.VehicleId) + 1 : 1;

            _requestForms.Add(newForm);
        }

        public void Delete(int id)
        {
            _requestForms.RemoveAll(f => f.VehicleId == id);
        }

        public void Edit(RequestForm form)
        {
            Delete(form.VehicleId);
            _requestForms.Add(form);
        }
    }
}
