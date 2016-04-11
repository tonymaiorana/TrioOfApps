using DvdLibrary.Models;
using System.Collections.Generic;

namespace DvdLibrary.Data.Interfaces
{
    public interface IBorrowerRepository
    {
        List<Borrower> GetAll();

        Borrower GetById(int id);

        Borrower GetByLastNamePhone(string lastName, string phoneNumber);

        Borrower AddBorrower(Borrower model);

        void Update(int id, Borrower model);

        void Delete(int id);
    }
}