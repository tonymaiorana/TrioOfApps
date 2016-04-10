using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Data;
using DvdLibrary.Models;

namespace DvdLibrary.BLL
{
    public class DvdOperations
    {
        private DvdRepository _repo = new DvdRepository();

        public Director AddDirector(Director director)
        {

            if (_repo.GetDirectorByName(director.DirectorFirstName, director.DirectLastName) == director)
            {
                _repo.AddDirector(director);
            }
            return director;
        }

        public Actor AddActor(Actor actor)
        {
            if (_repo.GetActorByName(actor.FirstName, actor.LastName) == actor)
            {
                _repo.AddActor(actor);
            }
            return actor;
        }

        //public Dvd AddDvd(Dvd newDvd)
        //{
        //    if()
        //}

        public void DeleteDvd(int movieId)
        {
            _repo.DeleteDvd(movieId);
        }

        public Dvd GetDvdById(int dvdId)
        {
            return _repo.GetDvdByID(dvdId);
        }
    }
}
