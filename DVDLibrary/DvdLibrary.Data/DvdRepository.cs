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
using System.Data;
using System.IO;


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
                                  "INNER JOIN BorrowerInfo bi ON bi.DvdID = d.DvdID";

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        currentDvd.DvdId = int.Parse(dr["DvdId"].ToString());
                        currentDvd.Title = dr["DvdTitle"].ToString();
                        currentDvd.MPAARating = (MPAARating) Enum.Parse(typeof (MPAARating), dr["MPAARating"].ToString());
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

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * " +
                                  "FROM DvdCatalog d " +
                                  "INNER JOIN Director di ON di.DirectorID = d.DirectorID " +
                                  "INNER JOIN Studio s ON s.StudioID = d.StudioID " +
                                  "INNER JOIN BorrowerInfo bi ON bi.DvdID = d.DvdID " +
                                  "INNER JOIN BorrowerName bn ON bn.BorrowerID = bi.BorrowerID " +
                                  "INNER JOIN DvdActor da ON da.DvdID = d.DvdID " +
                                  "INNER JOIN Actor a ON a.ActorId = da.ActorID " +
                                  "WHERE d.DvdId = @dvdId";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                        BorrowInfo borrowInfo = new BorrowInfo();
                        Studio studio = new Studio();
                        Director director = new Director();
                        List<Actor> dvdActors = new List<Actor>();

                        currentDvd.DvdId = int.Parse(dr["DvdId"].ToString());
                        currentDvd.Director = dr[""].ToString();
                        currentDvd.DvdActors.Add(dr["DirectorId"].ToString());
                        currentDvd.
                }
            }

            return currentDvd;
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

                cmd.Parameters.AddWithValue("@actorFirstName", directorFirstName);
                cmd.Parameters.AddWithValue("@actorLastName", directorLastName);

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
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                var param = new DynamicParameters();
                param.Add("DvdID", currentDvd);

                cn.Execute("AddDvd", param, commandType: CommandType.StoredProcedure);
            }
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

        public Dvd GetDvdByID(int dvdId)
        {
            using (SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                var dvd = cn.Query<Dvd>("SELECT Dvd.DvdId" +
                                        "FROM Dvd").ToList();
                return dvd.FirstOrDefault(d => d.DvdId == dvdId);
            }
        }
    }
}
