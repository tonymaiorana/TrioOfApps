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
            foreach (Director newMovieDirector in directors)
            {
                SelectListItem director = new SelectListItem()
                {
                    Text = newMovieDirector.DirectorFirstName + newMovieDirector.DirectorLastName,
                    Value = newMovieDirector.DirectorId.ToString()
                };
                MovieDirectors.Add(director);
            }
        }
    }
}