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
        public int BorrowerId { get; set; }
        public DateTime BorrowStartDate { get; set; }
        public DateTime BorrowEndDate { get; set; }
        public double BorrowerRating { get; set; }
        public string BorrowerComment { get; set; }
        public bool IsActive { get; set; }
    }
}