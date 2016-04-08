using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DvdLibrary.Models;


namespace DvdLibrary.Data
{
    public class DvdRepository
    {
        public List<Dvd> GetAllDvds()
        {
            List<Dvd> dvds = new List<Dvd>();

            return dvds;
        }

        public Dvd GetDvdByTitle(string dvdTitle)
        {
            Dvd currentDvd = new Dvd();

            return currentDvd;
        }

        public bool CheckDirectorByName(string directorName)
        {
            return true;
        }

        public void DeleteDvd(int dvdId)
        {
            
        }

        public void AddDvd(Dvd currentDvd)
        {
            
        }

        public void AddDirector(string directorName)
        {
            
        }

        public List<Actor> GetAllActors()
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                var Actors = cn.Query<Actor>("SELECT Actor.ActorId, Actor.FirstName, Actor.LastName" +
                                             "FROM Actor").ToList();

                return Actors;
            }
        }

    }
}
