using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DvdLibrary.Models;

namespace DvdLibrary.UI.Models
{
    public class DvdVM
    {
        public Dvd Dvd { get; set; }
        public List<SelectListItem> Director { get; set; }

        public DvdVM()
        {
            Director = new List<SelectListItem>();
        }
    }
}