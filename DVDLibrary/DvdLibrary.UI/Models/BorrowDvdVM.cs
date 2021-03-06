﻿using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.UI.Models
{
    public class BorrowDvdVM
    {
        public int BorrowerID { get; set; }
        public int DvdID { get; set; }
        public Dvd CurrentDvd { get; set; }
        public BorrowInfo CurrentBorrowInfo { get; set; }
    }
}