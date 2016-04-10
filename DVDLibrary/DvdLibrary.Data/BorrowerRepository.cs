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

        public List<Borrower> GetAll()
        {
            using (SqlConnection cn = new SqlConnection(
               ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                List<Borrower> borrowers = new List<Borrower>();

                return borrowers;
            }
        }

        public Borrower GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Borrower GetByLastNamePhone(string lastName, string phoneNumber)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                var borrowersList = cn.Query<Borrower>("SELECT Borrower.LastName, Borrower.PhoneNumber" +
                                             "FROM Borrower").ToList();
                return
                    borrowersList.FirstOrDefault(
                        b => b.BorrowerLastName == lastName && b.BorrowerPhoneNumber == phoneNumber);
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
            b.BorrowerLastName = model.BorrowerLastName;
            b.BorrowerFirstName = model.BorrowerFirstName;
            b.BorrowerPhoneNumber = model.BorrowerPhoneNumber;
        }

        public void Delete(int id)
        {
            Borrowers = GetAll();
            var borrowerToRemove = Borrowers.FirstOrDefault(b => b.BorrowerId == id);
            borrowerToRemove.IsActive = false;
        }
    }
}