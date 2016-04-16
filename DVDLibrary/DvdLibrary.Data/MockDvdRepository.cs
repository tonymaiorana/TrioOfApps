using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Models;

namespace DvdLibrary.Data
{
    public class MockDvdRepository
    {
        private static List<Dvd> _dvdLibrary = new List<Dvd>();
        private static List<Actor>_actors = new List<Actor>();
        private static List<BorrowInfo> _borrowInfos = new List<BorrowInfo>();
        private static Dictionary<string, string> _userComments = new Dictionary<string, string>();
        private static List<Director> _directors = new List<Director>();
        private static List<Studio> _studios = new List<Studio>();

        public MockDvdRepository()
        {
            _dvdLibrary.Add(new Dvd()
            {
                DvdId = 1,                
                BorrowInfo = new BorrowInfo()
                {
                    BorrowInfoId = 1,
                    DvdId = 1,
                    BorrowerComment = "Wow, this movie is great", BorrowerRating = 4,
                    DateBorrowed = new DateTime(2015,02,17),
                    DateReturned = new DateTime(2015,02,25),
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
                Director = new Director()
                {
                    DirectorId = 1,
                    FirstName = "Kaz",
                    LastName = "Nishimoto"
                },
                UserComments = "Great Movie",
                Title = "Pokemon 2000",
                IsAvailable = true,
                MPAARating = MPAARating.G,
                ReleaseDate = new DateTime(1998, 12, 10),
             }   
            );

            _studios.Add(new Studio
            {
                StudioId = 1,
                StudioName = "Warner"
            });
        }

        public List<Dvd> GetAllDvds()
        {
            return _dvdLibrary;
        }

        public Dvd GetDvdByTitle(string dvdTitle)
        {
            Dvd dvd = new Dvd();
            return dvd;
        }

        public Dvd GetDvdById(int dvdId)
        {
            foreach (Dvd dvd in _dvdLibrary)
            {
                if (dvd.DvdId == dvdId)
                {
                    return dvd;
                }                
            }
            return null;
        }

        public List<Actor> GetDvdActorsByDvdId(int dvdId)
        {
            return _actors;
        }

        public BorrowInfo GetBorrowInfoByDvdId(int dvdId)
        {
            BorrowInfo borrowInfo = new BorrowInfo();
            return borrowInfo;
        }

        public Dictionary<string, string> GetBorrowerCommentsByDvdId(int dvdId)
        {
            return _userComments;
        }

        public Director GetDirectorByName(string directorFirstName, string directorLastName)
        {
            Director director = new Director();
            return director;
        }

        public Actor GetActorByName(string actorFirstName, string actorLastName)
        {
            Actor actor = new Actor();
            return actor;
        }

        public Studio GetStudioByName(string studioName)
        {
            foreach (Studio studio in _studios)
            {
                if (studio.StudioName == studioName)
                {
                    return studio;
                }
            }
            return null;
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

 
    }
}
