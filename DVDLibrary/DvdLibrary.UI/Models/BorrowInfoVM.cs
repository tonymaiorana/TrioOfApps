using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.UI.Models
{
    public class BorrowInfoVM
    {
        public List<Dvd> Dvds { get; set; }
        public List<BorrowInfo> BorrowInfos { get; set; }
        public List<Borrower> Borrowers { get; set; }
    }
}