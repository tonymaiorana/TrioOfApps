using Dapper;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;

namespace DvdLibrary.Data
{
    public class DvdRepository
    {
        //GET ALL DVDS
        public List<Dvd> GetAllDvds()
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                List<Dvd> dvdLibrary = new List<Dvd>();

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * " +
                                  "FROM DvdCatalog d";

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentDvd = new Dvd();
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Title = dr["DvdTitle"].ToString();
                        currentDvd.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        currentDvd.MPAARating = (MPAARating)Enum.Parse(typeof(MPAARating), dr["MPAARating"].ToString());
                        currentDvd.BorrowInfo = GetBorrowInfoByDvdId(currentDvd.DvdId);

                        if (currentDvd.BorrowInfo != null)
                        {
                            currentDvd.IsAvailable = true;
                        }

                        dvdLibrary.Add(currentDvd);
                    }
                }
                return dvdLibrary;
            }
        }

        //----------------------------------------------------------------------

        //GET DVD BY TITLE - CALLS STUDIO, BORROWINFO, DVDACTORS, AND DIRECTOR BY ID
        public Dvd GetDvdByTitle(string dvdTitle)
        {
            Dvd currentDvd = new Dvd();

            using (
                SqlConnection cn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT di.DirectorID,di.FirstName AS FirstName,di.LastName AS LastName," +
                                  "s.StudioID, s.StudioName," +
                                  "d.DvdTitle,d.MPAARating,d.ReleaseDate,d.DvdId " +
                                  "FROM DvdCatalog d " +
                                  "INNER JOIN Director di ON di.DirectorID = d.DirectorID " +
                                  "INNER JOIN Studio s ON s.StudioID = d.StudioID " +
                                  "WHERE d.DvdTitle = @dvdTitle";

                cmd.Parameters.AddWithValue("@dvdTitle", dvdTitle);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        currentDvd.Title = dr["DvdTitle"].ToString();
                        currentDvd.MPAARating = (MPAARating)Enum.Parse(typeof(MPAARating), dr["MPAARating"].ToString());
                        currentDvd.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Director.DirectorId = (int)dr["DirectorID"];
                        currentDvd.Director.FirstName = dr["FirstName"].ToString();
                        currentDvd.Director.LastName = dr["LastName"].ToString();
                        currentDvd.Studio.StudioId = (int)dr["StudioID"];
                        currentDvd.Studio.StudioName = dr["StudioName"].ToString();
                        //CALL METHODS
                        currentDvd.DvdActors = GetDvdActorsByDvdId(currentDvd.DvdId);
                        currentDvd.BorrowInfo = GetBorrowInfoByDvdId(currentDvd.DvdId);
                        currentDvd.UserComments = GetBorrowerCommentsByDvdId(currentDvd.DvdId);

                        if (currentDvd.BorrowInfo != null)
                        {
                            currentDvd.IsAvailable = true;
                        }
                    }
                }
            }
            return currentDvd;
        }

        //----------------------------------------------------------------------

        //GET DVD BY ID - CALLS STUDIO, BORROWINFO, DVDACTORS, AND DIRECTOR BY ID
        public Dvd GetDvdById(int dvdId)
        {
            Dvd currentDvd = new Dvd();

            using (
                SqlConnection cn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT di.DirectorID,di.FirstName AS FirstName,di.LastName AS LastName," +
                                  "s.StudioID, s.StudioName," +
                                  "d.DvdTitle,d.MPAARating,d.ReleaseDate,d.DvdId " +
                                  "FROM DvdCatalog d " +
                                  "INNER JOIN Director di ON di.DirectorID = d.DirectorID " +
                                  "INNER JOIN Studio s ON s.StudioID = d.StudioID " +
                                  "WHERE d.DvdId = @dvdId";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        currentDvd.Title = dr["DvdTitle"].ToString();
                        currentDvd.MPAARating = (MPAARating)Enum.Parse(typeof(MPAARating), dr["MPAARating"].ToString());
                        currentDvd.ReleaseDate = (DateTime)dr["ReleaseDate"];
                        currentDvd.DvdId = (int)dr["DvdId"];
                        currentDvd.Director.DirectorId = (int)dr["DirectorID"];
                        currentDvd.Director.FirstName = dr["FirstName"].ToString();
                        currentDvd.Director.LastName = dr["LastName"].ToString();
                        currentDvd.Studio.StudioId = (int)dr["StudioID"];
                        currentDvd.Studio.StudioName = dr["StudioName"].ToString();
                        //CALL METHODS
                        currentDvd.DvdActors = GetDvdActorsByDvdId(currentDvd.DvdId);
                        currentDvd.BorrowInfo = GetBorrowInfoByDvdId(currentDvd.DvdId);
                        currentDvd.UserComments = GetBorrowerCommentsByDvdId(currentDvd.DvdId);

                        if (currentDvd.BorrowInfo != null)
                        {
                            currentDvd.IsAvailable = true;
                        }
                    }
                }
            }
            return currentDvd;
        }

        //----------------------------------------------------------------------

        //GET DVD PROPERTIES BY DVD ID
        public List<Actor> GetDvdActorsByDvdId(int dvdId)
        {
            List<Actor> dvdActors = new List<Actor>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText =
                    "SELECT a.ActorId, da.ActorId AS DvdActorId, da.DvdID, a.FirstName, a.LastName FROM DvdActor da " +
                    "INNER JOIN Actor a ON a.ActorID = da.ActorID " +
                    "WHERE da.DvdID = @dvdId";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Actor dvdActor = new Actor();
                        dvdActor.ActorId = int.Parse(dr["ActorId"].ToString());
                        dvdActor.FirstName = dr["FirstName"].ToString();
                        dvdActor.LastName = dr["LastName"].ToString();
                        dvdActors.Add(dvdActor);
                    }
                }
            }
            return dvdActors;
        }

        public BorrowInfo GetBorrowInfoByDvdId(int dvdId)
        {
            BorrowInfo borrowInfo = new BorrowInfo();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText =
                    "SELECT * FROM BorrowInfo bi " +
                    "INNER JOIN Borrower b ON b.BorrowerId = bi.BorrowerId " +
                    "WHERE bi.DvdId = @dvdId";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        borrowInfo.DvdId = int.Parse(dr["DvdId"].ToString());
                        borrowInfo.BorrowInfoId = int.Parse(dr["BorrowInfoId"].ToString());
                        borrowInfo.BorrowerComment = dr["BorrowerComment"].ToString();
                        borrowInfo.BorrowerRating = double.Parse(dr["BorrowerRating"].ToString());
                        borrowInfo.DateBorrowed = (DateTime)dr["DateBorrowed"];
                        if (dr["DateReturned"] != DBNull.Value)
                            borrowInfo.DateReturned = (DateTime)dr["DateReturned"];
                        borrowInfo.Borrower.BorrowerId = int.Parse(dr["BorrowerId"].ToString());
                        borrowInfo.Borrower.FirstName = dr["FirstName"].ToString();
                        borrowInfo.Borrower.LastName = dr["LastName"].ToString();
                        borrowInfo.Borrower.PhoneNumber = dr["PhoneNumber"].ToString();
                        borrowInfo.Borrower.IsActive = bool.Parse(dr["IsActive"].ToString());
                    }
                }
            }

            return borrowInfo;
        }

        public Dictionary<string, string> GetBorrowerCommentsByDvdId(int dvdId)
        {
            Dictionary<string, string> userComments = new Dictionary<string, string>();
            using (
                SqlConnection cn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText =
                    "SELECT bi.BorrowerComment, bi.DvdID, bi.BorrowerID, " +
                    "b.FirstName, b.LastName " +

                    "FROM BorrowInfo bi " +
                    "INNER JOIN Borrower b ON b.BorrowerID = bi.BorrowerID " +
                    "WHERE bi.DvdID = @dvdId";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        userComments.Add(dr["FirstName"] + " " + dr["LastName"], dr["BorrowerComment"].ToString());
                    }
                }
            }
            return userComments;
        }

        //----------------------------------------------------------------------

        //GET DVD PROPERTIES BY NAME
        public Director GetDirectorByName(string directorFirstName, string directorLastName)
        {
            Director director = new Director();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
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
                    director.FirstName = dr["FirstName"].ToString();
                    director.LastName = dr["LastName"].ToString();
                    director.DirectorId = int.Parse(dr["DirectorId"].ToString());
                }
                return director;
            }
        }

        public Actor GetActorByName(string actorFirstName, string actorLastName)
        {
            Actor actor = new Actor();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
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
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
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

        //----------------------------------------------------------------------

        //DELETE METHODS
        public void DeleteDvd(int dvdId)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DVD"].ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("DvdId", dvdId);

                cn.Execute("DeleteDvd", param, commandType: CommandType.StoredProcedure);
            }
        }

        //----------------------------------------------------------------------
        //ADD METHODS
        public void AddDvd(Dvd newDvd)
        {
            int currentDvdDirectorId = AddDirector(newDvd.Director);
            int currentDvdStudioId = AddStudio(newDvd.Studio);

            Dvd currentDvd = new Dvd();

            using (
                SqlConnection cn =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO DVDCatalog(DirectorID, StudioID" +
                                                "DvdTitle, ReleaseDate, MPAARating, UserComments) VALUES(@DirectorID, @StudioID, @ReleaseDate, @MPAARating, @UserComments)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@DirectorID", currentDvdDirectorId);
                cmd.Parameters.AddWithValue("@StudioID", currentDvdStudioId);
                cmd.Parameters.AddWithValue("@ReleaseDate", currentDvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@MPAARating", currentDvd.MPAARating);
                cmd.Parameters.AddWithValue("@UserComments", currentDvd.UserComments);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int AddDirector(Director director)
        {
            using (SqlConnection cn =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Director (FirstName, LastName) VALUES (@firstname, @lastname)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@firstname", director.FirstName);
                cmd.Parameters.AddWithValue("@lastname", director.LastName);
                cn.Open();
                cmd.ExecuteNonQuery();
                Director currentDirector = GetDirectorByName(director.FirstName, director.LastName);
                int newDirectorId = currentDirector.DirectorId;
                return newDirectorId;
            }
        }

        public void AddActor(Actor actor)
        {
        }

        public int AddStudio(Studio studio)
        {
            using (SqlConnection cn =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Studio (StudioName) VALUES (@StudioName)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@StudioName", studio.StudioName);
                cn.Open();
                cmd.ExecuteNonQuery();
                Studio currentStudio = GetStudioByName(studio.StudioName);
                int newStudioId = currentStudio.StudioId;
                return newStudioId;
            }
        }
        //----------------------------------------------------------------------
        public List<Director> GetAllDirectors()
        {
            using (var _cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVD"].ConnectionString))
            {
                List<Director> AllDirectors = new List<Director>();
                AllDirectors = _cn.Query<Director>("SELECT * FROM Director").ToList();
                return AllDirectors;
            }
        }
    }
}