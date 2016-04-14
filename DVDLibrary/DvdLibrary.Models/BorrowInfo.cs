﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models
{
    public class BorrowInfo
    {
        public int BorrowInfoId { get; set; }
        public Dvd Dvd { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; }
        public double? BorrowerRating { get; set; }
        public string BorrowerComment { get; set; }
        public bool IsActive { get; set; }
    }
}