using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.UI.Models
{
    public class ListDvdVM
    {
        public List<Dvd> Dvds { get; set; }

        //public List<Borrower> Borrowers { get; set; }
        public Borrower currentBorrower { get; set; }
    }
}