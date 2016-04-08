using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DvdLibrary.Models;

namespace DvdLibrary.UI.Models
{
    public class AddDvdVM
    {
        public Dvd newDvd { get; set; }
        public List<Dvd> Dvds { get; set; }
        public MPAARating MpaaRating;
        public List<SelectListItem> MpaaDropDown { get; set; }

        public AddDvdVM(List<Dvd> dvds)
        {
            MpaaDropDown = new List<SelectListItem>();
            foreach (var rating in Enum.GetValues(typeof(MPAARating)))
            {
                var ListItem = new SelectListItem {Text = rating.ToString(), Value = rating.ToString()};
               MpaaDropDown.Add(ListItem);
            }
           

        }

    }
}