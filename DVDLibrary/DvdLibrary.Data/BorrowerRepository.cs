using Dapper;
using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private List<Borrower> Borrowers = new List<Borrower>();

        private string constr;

        public BorrowerRepository()
        {
            constr = ConfigurationManager.ConnectionStrings["DVD"].ConnectionString;
        }

        public List<Borrower> GetAll()
        {
            using (var _cn = new SqlConnection(constr))
            {
                List<Borrower> borrowers = new List<Borrower>();
                borrowers = _cn.Query<Borrower>("SELECT * FROM Borrower WHERE Borrower.IsActive = 'true' ").ToList();
                return borrowers;
            }
        }

        public Borrower GetById(int id)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                var borrower = _cn.Query<Borrower>("SELECT * " +
                                                  "FROM Borrower " +
                                                  "WHERE BorrowerID = @ID ", parameters).FirstOrDefault();
                return borrower;
            }
        }

        public Borrower GetByLastNamePhone(string lastName, string phoneNumber)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("LastName", lastName);
                parameters.Add("PhoneNumber", phoneNumber);
                var borrower = _cn.Query<Borrower>("SELECT * " +
                                             "FROM Borrower WHERE LastName = @LastName AND PhoneNumber = @PhoneNumber ", parameters).FirstOrDefault();
                return borrower;
            }
        }

        public Borrower AddBorrower(Borrower model)
        {
            Borrowers = GetAll();
            Borrowers.Add(model);
            model.IsActive = true;
            model.FirstName = model.FirstName.ToUpper();
            model.LastName = model.LastName.ToUpper();
            using (var _cn = new SqlConnection(constr))
            {
                string query = "INSERT INTO Borrower (FirstName, LastName, PhoneNumber, IsActive) VALUES (@FirstName, @LastName, @PhoneNumber, @IsActive) ";
                _cn.Execute(query, new { model.FirstName, model.LastName, model.PhoneNumber, model.IsActive });
            }

            return model;
        }

        public void Update(int id, Borrower model)
        {
            Borrowers = GetAll();
            Borrower b = Borrowers.SingleOrDefault(bb => bb.BorrowerId == id);
            b.BorrowerId = id;
            b.LastName = model.LastName;
            b.FirstName = model.FirstName;
            b.PhoneNumber = model.PhoneNumber;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("BorrowerId", id);
                parameters.Add("FirstName", model.FirstName);
                parameters.Add("LastName", model.LastName);
                parameters.Add("PhoneNumber", model.PhoneNumber);

                string query =
                    "UPDATE Borrower SET FirstName =@FirstName, LastName = @LastName, PhoneNumber= @PhoneNumber " +
                    "WHERE BorrowerId = @id ";
                _cn.Execute(query, new { id, b.FirstName, b.LastName, b.PhoneNumber });
            }
        }

        public void Delete(int id)
        {
            Borrowers = GetAll();
            var borrowerToRemove = Borrowers.FirstOrDefault(b => b.BorrowerId == id);
            borrowerToRemove.IsActive = false;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("IsActive", borrowerToRemove.IsActive);
                parameters.Add("ID", id);
                string query = "UPDATE Borrower SET IsActive = @IsActive " +
                                                "WHERE BorrowerId = @id ";
                _cn.Execute(query, new { borrowerToRemove.IsActive, id });
            }
        }
    }
}