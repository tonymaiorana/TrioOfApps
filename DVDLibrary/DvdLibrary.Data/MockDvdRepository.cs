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

        public MockDvdRepository()
        {
            _dvdLibrary.Add(new Dvd()
            {
                DvdId = 1,
                Director = new Director() {DirectorId = 1, FirstName = "Bob", LastName = "Joe"},
                BorrowInfo = new BorrowInfo()
                {
                    BorrowInfoId = 1,
                    DvdId = 1,
                    BorrowerComment = "Wow, this movie is great", BorrowerRating = 4,
                    DateBorrowed = new DateTime(02-17-2015),
                    DateReturned = new DateTime(02-25-2015),
                    DvdTitle = "Pokemon 2000",
                    IsActive = false,
                    Borrower = new Borrower()
                    {
                        FirstName = "Billy",
                        LastName = "Johnson",
                        BorrowerId = 1,
                        PhoneNumber = "330-203-9292"
                    }
                },
                DvdActors = new List<Actor>()
                {
                   new Actor()
                   {
                       ActorId = 1,
                       FirstName = "Zac",
                       LastName = "Moonyham"
                   } 
                },
                Studio = new Studio()
                {
                    StudioId = 1,
                    StudioName = "Warner"
                },
                UserComments = new Dictionary<string, string>()
                {
                    {"Hi", "hi"}
                },
                Title = "Pokemon 2000",
                IsAvailable = true,
                MPAARating = MPAARating.G,
                ReleaseDate = new DateTime(12-10-1998),
             }   
            );
        }

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
