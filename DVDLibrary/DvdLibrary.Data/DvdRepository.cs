using Dapper;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
    public class DvdRepository
    {
        //GET ALL DVDS

        public List<Dvd> GetAllDvds()
        {
            Dvd currentDvd = new Dvd();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                List<Dvd> DvdLibrary = new List<Dvd>();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM DvdCatalog d " +
                                  "INNER JOIN BorrowInfo bi ON bi.DvdID = d.DvdID";

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        currentDvd.DvdId = int.Parse(dr["DvdId"].ToString());
                        currentDvd.Title = dr["DvdTitle"].ToString();
                        currentDvd.MPAARating = (MPAARating)Enum.Parse(typeof(MPAARating), dr["MPAARating"].ToString());
                        currentDvd.AverageRating = double.Parse(dr["AverageRating"].ToString());
                        currentDvd.BorrowInfo.BorrowInfoId = int.Parse(dr["BorrowInfoId"].ToString());
                        currentDvd.BorrowInfo.IsActive = bool.Parse(dr["IsActive"].ToString());
                    }
                }
                return DvdLibrary;
            }
        }

        //GET DVD BY ID - CALLS STUDIO, BORROWINFO, DVDACTORS, AND DIRECTOR BY ID

        public Dvd GetDvdById(int dvdId)
        {
            Dvd currentDvd = new Dvd();

            using (
                SqlConnection cn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT di.DirectorID,di.FirstName AS DirectorFirstName,di.LastName AS DirectorLastName " +
                                  "s.StudioID, s.StudioName " +                    
                                  "FROM DvdCatalog d " +
                                  "INNER JOIN Director di ON di.DirectorID = d.DirectorID " +
                                  "INNER JOIN Studio s ON s.StudioID = d.StudioID " +
                                  "WHERE d.DvdId = @dvdId";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    currentDvd.Title = dr["Title"].ToString();
                    currentDvd.AverageRating = double.Parse(dr["AverageRating"].ToString());
                    currentDvd.MPAARating = (MPAARating)Enum.Parse(typeof(MPAARating), dr["MPAARating"].ToString());
                    currentDvd.ReleaseDate = DateTime.Parse(dr["ReleaseDate"].ToString());
                    currentDvd.DvdId = int.Parse(dr["DvdId"].ToString());
                    currentDvd.Director.DirectorId = int.Parse(dr["DirectorId"].ToString());
                    currentDvd.Director.DirectorFirstName = dr["DirectorFirstName"].ToString();
                    currentDvd.Director.DirectorLastName = dr["DirectorLsatName"].ToString();
                    currentDvd.Studio.StudioId = int.Parse(dr["StudioId"].ToString());
                    currentDvd.Studio.StudioName = dr["StudioName"].ToString();
                    currentDvd.DvdActors = GetDvdActorsByDvdId(currentDvd.DvdId);
                    currentDvd.BorrowInfo = GetBorrowInfoByDvdId(currentDvd.DvdId);
                    currentDvd.UserComments = GetUserCommentsByDvdId(currentDvd.DvdId);

                    if (currentDvd.BorrowInfo != null)
                    {
                        currentDvd.IsAvailable = true;
                    }
                }
            }
            return currentDvd;
        }

        public List<Actor> GetDvdActorsByDvdId(int dvdId)
        {
            List<Actor> dvdActors = new List<Actor>();

            return dvdActors;
        }

        public BorrowInfo GetBorrowInfoByDvdId(int dvdId)
        {
            BorrowInfo borrowInfo = new BorrowInfo();

            return borrowInfo;
        }

        public List<string> GetUserCommentsByDvdId(int dvdId)
        {
            List<string> userComments = new List<string>();

            return userComments;
        }

        public Director GetDirectorByName(string directorFirstName, string directorLastName)
        {
            Director director = new Director();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM Director d " +
                                  "WHERE d.FirstName = @directorFirstName, d.LastName = @directorLastName";

                cmd.Parameters.AddWithValue("@directorFirstName", directorFirstName);
                cmd.Parameters.AddWithValue("@directorLastName", directorLastName);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    director.DirectorFirstName = dr["FirstName"].ToString();
                    director.DirectorLastName = dr["LastName"].ToString();
                    director.DirectorId = int.Parse(dr["DirectorId"].ToString());
                }
                return director;
            }
        }

        public Actor GetActorByName(string actorFirstName, string actorLastName)
        {
            Actor actor = new Actor();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM Actor a " +
                                  "WHERE a.FirstName = @actorFirstName, a.LastName = @actorLastName";
                cmd.Parameters.AddWithValue("@actorFirstName", actorFirstName);
                cmd.Parameters.AddWithValue("@actorLastName", actorLastName);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    actor.FirstName = dr["FirstName"].ToString();
                    actor.LastName = dr["LastName"].ToString();
                    actor.ActorId = int.Parse(dr["ActorId"].ToString());
                }
            }
            return actor;
        }

        public Studio GetStudioByName(string studioName)
        {
            Studio studio = new Studio();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM Studio s " +
                                  "WHERE s.StudioName = @actorFirstName";
                cmd.Parameters.AddWithValue("@StudioName", studioName);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    studio.StudioName = dr["StudioName"].ToString();
                    studio.StudioId = int.Parse(dr["StudioId"].ToString());
                }
            }
            return studio;
        }

        public void DeleteDvd(int dvdId)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("DvdID", dvdId);

                cn.Execute("DeleteDvd", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddDvd(Dvd newDvd)
        {
            //Dvd _currentDvd = new Dvd();

            //using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "INSERT INTO DVDCatalog" +
            //                      "(DvdTitle, ReleaseDate, MPAARating, UserComments)";

            //    cmd.Parameters.AddWithValue("@actorFirstName", directorFirstName);
            //    cmd.Parameters.AddWithValue("@actorLastName", directorLastName);

            //    cmd.Connection = cn;
            //    cn.Open();

            //    using (SqlDataReader dr = cmd.ExecuteReader())
            //    {
            //        director.DirectorFirstName = dr["FirstName"].ToString();
            //        director.DirectorLastName = dr["LastName"].ToString();
            //        director.DirectorId = int.Parse(dr["DirectorId"].ToString());
            //    }
            //    return director;
            //}
        }

        public void AddDirector(Director director)
        {
        }

        public void AddActor(Actor actor)
        {
        }

        public void AddStudio(Studio studio)
        {
        }

        /*public Dvd GetDvdByID(int dvdId)
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                var dvd = cn.Query<Dvd>("SELECT Dvd.DvdId" +
                                        "FROM Dvd").ToList();
                return dvd.FirstOrDefault(d => d.DvdId == dvdId);
            }
        }*/
    }
}