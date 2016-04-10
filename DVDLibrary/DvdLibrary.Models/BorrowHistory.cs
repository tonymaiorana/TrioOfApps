using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models
{
    public class BorrowHistory
    {
        public int DvdID { get; set; }
        public string DvdTitle { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }
        public int UserRating { get; set; }
        public string UserComments { get; set; }
    }
}