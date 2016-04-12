using Dapper;
using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private SqlConnection _cn;

        public BorrowerRepository()
        {
            _cn = new SqlConnection();
            _cn.ConnectionString = ConfigurationManager.ConnectionStrings["Dvd"].ConnectionString;
        }
   
        public List<Borrower> GetAll()
        {
            using (_cn)
            {
                List<Borrower> borrowers = new List<Borrower>();
                borrowers = _cn.Query<Borrower>("SELECT * FROM Borrower").ToList();
                return borrowers;
            }
        }

        public Borrower GetById(int id)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Dvd"].ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                var borrower = cn.Query<Borrower>("SELECT FirstName, LastName, PhoneNumber " +
                                                  "FROM Borrower " +
                                                  "WHERE BorrowerID = @ID ", parameters).FirstOrDefault();
                return borrower;
            }
        }

        public Borrower GetByLastNamePhone(string lastName, string phoneNumber)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Dvd"].ConnectionString))
            {
                var borrowersList = cn.Query<Borrower>("SELECT FirstName, LastName, PhoneNumber " +
                                             "FROM Borrower ").ToList();
                return
                    borrowersList.FirstOrDefault(
                        b => b.LastName == lastName && b.PhoneNumber == phoneNumber);
            }
        }

        public Borrower AddBorrower(Borrower model)
        {
            Borrowers = GetAll();
            Borrowers.Add(model);

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
        }

        public void Delete(int id)
        {
            Borrowers = GetAll();
            var borrowerToRemove = Borrowers.FirstOrDefault(b => b.BorrowerId == id);
            borrowerToRemove.IsActive = false;
        }
    }
}