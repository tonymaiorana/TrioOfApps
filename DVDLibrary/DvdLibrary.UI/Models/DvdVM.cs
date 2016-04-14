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
        public List<SelectListItem> MovieDirectors { get; set; }

        public DvdVM(List<Director> directors)
        {
            MovieDirectors = new List<SelectListItem>();
            foreach (var dir in directors)
            {
                string director = dir.FirstName +' '+ dir.LastName;
                var LI = new SelectListItem
                { Text = director,     
                Value = dir.DirectorId.ToString()      
                };
                MovieDirectors.Add(LI);
            }
        }
    }
}