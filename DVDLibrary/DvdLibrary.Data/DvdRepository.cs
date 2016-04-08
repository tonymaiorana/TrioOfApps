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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;


namespace DvdLibrary.Data
{
    public class DvdRepository
    {
        public List<Dvd> GetAllDvds()
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                List<Dvd> dvds = new List<Dvd>();

                return dvds;
            }
        }

        public Dvd GetDvdByTitle(string dvdTitle)
        {
            Dvd currentDvd = new Dvd();

            return currentDvd;
        }

        public Director GetDirectorByName(string directorFirstName, string directorLastName)
        {
            Director director = new Director();
            return director;
        }

        public Actor GetActorByName(string ActorFirstName, string ActorLastName)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                var Actors = cn.Query<Actor>("SELECT Actor.ActorId, Actor.FirstName, Actor.LastName" +
                                             "FROM Actor").ToList();
                Actor actor = new Actor();
                return actor;
            }
        }

        public void DeleteDvd(int dvdId)
        {
           using(SqlConnection cn = new SqlConnection(ConfigurationManager.
               ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("DvdID", dvdId);

                cn.Execute("DeleteDvd", param, commandType: CommandType.StoredProcedure);

            }
        }

        public void AddDvd(Dvd currentDvd)
        {
            
        }

        public void AddDirector(Director director)
        {
            
        }

        public void AddActor(Actor actor)
        {
            
        }

    }
}
