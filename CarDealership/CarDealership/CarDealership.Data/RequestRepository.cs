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
                                                  "WHERE VehicleID = @ID ", parameters).FirstOrDefault();
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
            var formToUpdate = GetById(id);
            formToUpdate = form;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", id);
                parameters.Add("VehicleId", formToUpdate.VehicleId);
                parameters.Add("FirstName", formToUpdate.FirstName);
                parameters.Add("LastName", formToUpdate.LastName);
                parameters.Add("EmailAddress", formToUpdate.EmailAddress);
                parameters.Add("PhoneNumber", formToUpdate.PhoneNumber);
                parameters.Add("BestTimeToCall", formToUpdate.BestTimeToCall);
                parameters.Add("PreferedContactMethod", formToUpdate.PreferedContactMethod);
                parameters.Add("DateNeedToPurchaseBy", formToUpdate.DateNeedToPurchaseBy);
                parameters.Add("AdditionalInfo", formToUpdate.AdditionalInfo);
                parameters.Add("LastContacted", formToUpdate.LastContacted);
                parameters.Add("RequestFormStatus", formToUpdate.RequestFormStatus);

                string query = "UPDATE RequestForm SET VehicleId=@VehicleId, FirstName=@FirstName, LastName=@LastName, " +
                               "EmailAddress=@EmailAddress, PhoneNumber=@PhoneNumber, BestTimeToCall=@BestTimeToCall, " +
                               "PreferedContactMethod=@PreferedContactMethod, DateNeedToPurchaseBy=@DateNeedToPurchaseBy, " +
                               "AdditionalInfo=@AdditionalInfo, LastContacted=@LastContacted, RequestFormStatus=@RequestFormStatus " +
                               "WHERE VehicleId=@Id";
                _cn.Execute(query, parameters);
            }
        }

        public void Delete(int id)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Vehicle", id);
                string query = "DELETE FROM RequestForm WHERE VehicleId = @id ";
                _cn.Execute(query, parameters);
            }
        }
    }
}