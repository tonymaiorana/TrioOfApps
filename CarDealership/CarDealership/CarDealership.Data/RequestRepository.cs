using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CarDealership.Data
{
    public class RequestRepository : IRequestRepository
    {
        private string constr;

        public RequestRepository()
        {
            constr = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;
        }

        public List<RequestForm> GetAll()
        {
            using (var _cn = new SqlConnection(constr))
            {
                List<RequestForm> Requests = new List<RequestForm>();

                Requests = _cn.Query<RequestForm>("SELECT * FROM RequestForm ").ToList();
                return Requests;
            }
        }

        public RequestForm GetById(int id)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                var form = _cn.Query<RequestForm>("SELECT * " +
                                                  "FROM RequestForm " +
                                                  "WHERE RequestFormId = @ID ", parameters).FirstOrDefault();
                return form;
            }
        }

        public void Add(RequestForm form)
        {
             using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();

                parameters.Add("VehicleId", form.VehicleId);
                parameters.Add("FirstName", form.FirstName);
                parameters.Add("LastName", form.LastName);
                parameters.Add("EmailAddress", form.EmailAddress);
                parameters.Add("PhoneNumber", form.PhoneNumber);
                parameters.Add("BestTimeToCall", form.BestTimeToCall);
                parameters.Add("PreferedContactMethod", form.PreferedContactMethod);
                parameters.Add("DateNeedToPurchaseBy", form.DateNeedToPurchaseBy);
                parameters.Add("AdditionalInfo", form.AdditionalInfo);
                parameters.Add("LastContacted", form.LastContacted);
                parameters.Add("RequestFormStatus", form.RequestFormStatus);

                string query = "INSERT INTO RequestForm (VehicleId, FirstName, LastName, EmailAddress, PhoneNumber, BestTimeToCall, " +
                               "PreferedContactMethod, DateNeedToPurchaseBy, AdditionalInfo, LastContacted, RequestFormStatus) " +
                               "VALUES (@VehicleId, @FirstName, @LastName, @EmailAddress, @PhoneNumber, @BestTimeToCall, " +
                               "@PreferedContactMethod, @DateNeedToPurchaseBy, @AdditionalInfo, @LastContacted, " +
                               "@RequestFormStatus) ";
                _cn.Execute(query, parameters);
            }
        }

        public void Update(int id, RequestForm form)
        {
            //var formToUpdate = GetById(id);
            ////form.LastContacted = formToUpdate.LastContacted;
            //formToUpdate.RequestFormStatus = form.RequestFormStatus;
            //formToUpdate.FirstName = form.FirstName;
            //formToUpdate.LastName = form.LastName;
            //formToUpdate.PhoneNumber = form.PhoneNumber;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);          
                parameters.Add("FirstName", form.FirstName);
                parameters.Add("LastName", form.LastName);
                //parameters.Add("EmailAddress", formToUpdate.EmailAddress);
                parameters.Add("PhoneNumber", form.PhoneNumber);
                //parameters.Add("BestTimeToCall", formToUpdate.BestTimeToCall);
                //parameters.Add("PreferedContactMethod", formToUpdate.PreferedContactMethod);
                //parameters.Add("DateNeedToPurchaseBy", formToUpdate.DateNeedToPurchaseBy);
                //parameters.Add("AdditionalInfo", formToUpdate.AdditionalInfo);
                parameters.Add("LastContacted", DateTime.Today);
                parameters.Add("RequestFormStatus", form.RequestFormStatus);

                string query = "UPDATE RequestForm SET FirstName=@FirstName, LastName=@LastName, " +
                               "PhoneNumber=@PhoneNumber, LastContacted=@LastContacted, RequestFormStatus=@RequestFormStatus " +
                               "WHERE RequestFormId = @ID";
                _cn.Execute(query, parameters);
            }
        }

        public void Delete(int id)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("RequestFormId", id);
                string query = "DELETE FROM RequestForm WHERE RequestFormId = @RequestFormId";
                _cn.Execute(query, parameters);
            }
        }
    }
}