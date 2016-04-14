using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;

namespace DvdLibrary.Data
{
    public class MockDvdRepository : IDvdRepository
    {
        private static List<Dvd> _dvdLibrary = new List<Dvd>();
        private static Dvd _currentDvd = new Dvd();
        private static List<Actor>_actors = new List<Actor>();
        private static BorrowInfo _borrowInfo = new BorrowInfo();
        private static Dictionary<string, string> _userComments = new Dictionary<string, string>();
        private static Director _director = new Director();
        private static Actor _actor = new Actor();
        private static Studio _studio = new Studio();
        private static List<Director> _directors = new List<Director>();

        public List<Dvd> GetAllDvds()
        {
            return _dvdLibrary;
        }

        public Dvd GetDvdByTitle(string dvdTitle)
        {
            return _currentDvd;
        }

        public Dvd GetDvdById(int dvdId)
        {
            return _currentDvd;
        }

        public List<Actor> GetDvdActorsByDvdId(int dvdId)
        {
            return _actors;
        }

        public BorrowInfo GetBorrowInfoByDvdId(int dvdId)
        {
            return _borrowInfo;
        }

        public Dictionary<string, string> GetBorrowerCommentsByDvdId(int dvdId)
        {
            return _userComments;
        }

        public Director GetDirectorByName(string directorFirstName, string directorLastName)
        {
            return _director;
        }

        public Actor GetActorByName(string actorFirstName, string actorLastName)
        {
            return _actor;
        }

        public Studio GetStudioByName(string studioName)
        {
            return _studio;
        }

        public void DeleteDvd(int dvdId)
        {
            _dvdLibrary.RemoveAll(d => d.DvdId == dvdId);
        }

        public void AddDvd(Dvd newDvd)
        {
            newDvd.DvdId = (_dvdLibrary.Any()) ? _dvdLibrary.Max(d => d.DvdId) + 1 : 1;
            _dvdLibrary.Add(newDvd);
        }

        public int AddDirector(Director director)
        {
            return director.DirectorId;
        }

        public void AddActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public int AddStudio(Studio studio)
        {
            return studio.StudioId;
        }

        public List<Director> GetAllDirectors()
        {
            return _directors;
        }
    }
}
