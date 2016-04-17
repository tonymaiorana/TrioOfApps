using DvdLibrary.Models;
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
        public List<SelectListItem>  StudioList { get; set; }
        public List<SelectListItem>  ActorList { get; set; }

        public DvdVM()
        {
            Dvd = new Dvd();
        }

        public DvdVM(List<Director> directors, List<Studio> studios, List<DvdActor> actors)
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

            StudioList = new List<SelectListItem>();
            foreach (var stu in studios)
            {
                var LI = new SelectListItem
                {
                    Text = stu.StudioName,
                    Value = stu.StudioId.ToString()
                };
                StudioList.Add(LI);
            }

            ActorList = new List<SelectListItem>();
            Actor actor = new Actor();
            foreach (var act in actors)
            {

                var LI = new SelectListItem
                {
                    Text = actor.FirstName + ' ' + actor.LastName,
                    Value = act.ActorId.ToString()
                };
                MovieDirectors.Add(LI);
            }
        }
    }
}