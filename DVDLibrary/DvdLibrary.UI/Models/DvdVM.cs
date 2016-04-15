﻿using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DvdLibrary.UI.Models
{
    public class DvdVM
    {
        public Dvd Dvd { get; set; }
        public List<SelectListItem> MovieDirectors { get; set; }

        public List<Dvd> Dvds { get; set; }

        public DvdVM()
        {
            Dvd = new Dvd();
        }

        public DvdVM(List<Director> directors)
        {
            MovieDirectors = new List<SelectListItem>();
            //MovieDirectors.Add(new SelectListItem { Text = "", Value = "", Selected = true });
            foreach (var dir in directors)
            {
                
                var LI = new SelectListItem
                {
                    Text = dir.FirstName+' '+dir.LastName,
                    Value = dir.DirectorId.ToString()
                };
                MovieDirectors.Add(LI);
            }
        }
    }
}