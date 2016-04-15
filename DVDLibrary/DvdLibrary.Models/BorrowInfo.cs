using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models
{
    public class BorrowInfo
    {
        public int BorrowInfoId { get; set; }
        public int DvdId { get; set; }
        public string DvdTitle { get; set; }
        public Borrower CurrentBorrower { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; }
        public int? BorrowerRating { get; set; }
        public string BorrowerComment { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BorrowerID { get; set; }

        public BorrowInfo()
        {
            CurrentBorrower = new Borrower();
            CurrentBorrower.FirstName = FirstName;
            CurrentBorrower.LastName = LastName;
            CurrentBorrower.BorrowerId = BorrowerID;
        }
    }
}