using System.Collections.Generic;
using DvdLibrary.Models;

namespace DvdLibrary.Data
{
    public interface IDvdRepository
    {
        List<Dvd> GetAllDvds();
        Dvd GetDvdByTitle(string dvdTitle);
        Dvd GetDvdById(int dvdId);
        List<Actor> GetDvdActorsByDvdId(int dvdId);
        BorrowInfo GetBorrowInfoByDvdId(int dvdId);
        Dictionary<string, string> GetBorrowerCommentsByDvdId(int dvdId);
        Director GetDirectorByName(string directorFirstName, string directorLastName);
        Actor GetActorByName(string actorFirstName, string actorLastName);
        Studio GetStudioByName(string studioName);
        void DeleteDvd(int dvdId);
        void AddDvd(Dvd newDvd);
        int AddDirector(Director director);
        void AddActor(Actor actor);
        int AddStudio(Studio studio);
        List<Director> GetAllDirectors();
    }
}