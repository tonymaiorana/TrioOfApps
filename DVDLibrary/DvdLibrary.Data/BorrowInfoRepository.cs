using Dapper;
using DvdLibrary.Data.Interfaces;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data
{
    public class BorrowInfoRepository : IBorrowInfoRepository
    {
        private List<BorrowInfo> BorrowInfoList = new List<BorrowInfo>();

        private string constr;

        public BorrowInfoRepository()
        {
            constr = ConfigurationManager.ConnectionStrings["DVD"].ConnectionString;
        }

        public List<BorrowInfo> GetAll()
        {
            using (var _cn = new SqlConnection(constr))
            {
                var borrowInfoList = _cn.Query<BorrowInfo>("SELECT * FROM BorrowInfo INNER JOIN Borrower " +
                    "ON BorrowInfo.BorrowerID = Borrower.BorrowerID " +
                    "INNER JOIN DVDCatalog ON BorrowInfo.DvdID=DVDCatalog.DvdID ").ToList();
                return borrowInfoList;
            }
        }

        public BorrowInfo GetById(int borrowInfoID)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("BorrowInfoID", borrowInfoID);
                var borrowInfo = _cn.Query<BorrowInfo>("SELECT * FROM BorrowInfo INNER JOIN Borrower " +
                    "ON BorrowInfo.BorrowerID = Borrower.BorrowerID " +
                    "INNER JOIN DVDCatalog ON BorrowInfo.DvdID=DVDCatalog.DvdID " +
                    "WHERE BorrowInfo.BorrowInfoID = @BorrowInfoID", parameters).FirstOrDefault();
                return borrowInfo;
            }
        }

        public BorrowInfo GetByDvdId(int dvdId)
        {
            throw new NotImplementedException();
        }

        public List<BorrowInfo> GetByBorrowerId(int borrowerId)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("BorrowerID", borrowerId);
                List<BorrowInfo> borrowInfoByBorrower = new List<BorrowInfo>();
                borrowInfoByBorrower = _cn.Query<BorrowInfo>("SELECT * FROM BorrowInfo " +
                    "INNER JOIN DVDCatalog ON BorrowInfo.DvdID=DVDCatalog.DvdID " +
                                             "WHERE BorrowerID=@BorrowerID ", parameters).ToList();
                return borrowInfoByBorrower;
            }
        }

        public BorrowInfo AddBorrowInfo(BorrowInfo model)
        {
            BorrowInfoList = GetAll();
            BorrowInfoList.Add(model);
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();

                parameters.Add("DvdID", model.DvdId);
                parameters.Add("BorrowerID", model.Borrower.BorrowerId);
                parameters.Add("DateBorrowed", model.DateBorrowed);
                parameters.Add("DateReturned", model.DateReturned);
                parameters.Add("BorrowerRating", model.BorrowerRating);
                parameters.Add("BorrowerComment", model.BorrowerComment);
                parameters.Add("IsActive", model.IsActive);

                string query = "INSERT INTO BorrowInfo (DvdID, BorrowerID, DateBorrowed, DateReturned, BorrowerRating, BorrowerComment, IsActive) VALUES (@DvdID, @BorrowerID, @DateBorrowed, @DateReturned, @BorrowerRating, @BorrowerComment, @IsActive) ";
                _cn.Execute(query, parameters);
            }

            return model;
        }

        public void Update(int id, BorrowInfo model)
        {
            BorrowInfoList = GetAll();
            BorrowInfo b = BorrowInfoList.SingleOrDefault(bb => bb.BorrowInfoId == id);
            b.BorrowInfoId = id;
            b.DvdId = model.DvdId;
            b.Borrower.BorrowerId = model.Borrower.BorrowerId;
            b.DateBorrowed = model.DateBorrowed;
            b.DateReturned = model.DateReturned;
            b.BorrowerRating = model.BorrowerRating;
            b.BorrowerComment = model.BorrowerComment;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("DvdID", model.DvdId);
                parameters.Add("BorrowerID", model.Borrower.BorrowerId);
                parameters.Add("DateBorrowed", model.DateBorrowed);
                parameters.Add("DateReturned", model.DateReturned);
                parameters.Add("BorrowerRating", model.BorrowerRating);
                parameters.Add("BorrowerComment", model.BorrowerComment);

                string query =
                    "UPDATE Borrower SET DvdID=@DvdID, BorrowerID=@BorrowerID, DateBorrowed = @DateBorrowed, DateReturned = @DateReturned, " +
                    "BorrowerRating =@BorrowerRating, BorrowerComment=@BorrowerComment " +
                    "WHERE BorrowerID = @id ";
                _cn.Execute(query, parameters);
            }
        }

        public void Delete(int id)
        {
            BorrowInfoList = GetAll();
            var borrowInfoToRemove = BorrowInfoList.FirstOrDefault(b => b.BorrowInfoId == id);
            borrowInfoToRemove.IsActive = false;
            borrowInfoToRemove.DateReturned = DateTime.Today;
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("IsActive", borrowInfoToRemove.IsActive);
                parameters.Add("DateReturned", borrowInfoToRemove.DateReturned);
                parameters.Add("id", id);
                string query = "UPDATE BorrowInfo SET IsActive = @IsActive, DateReturned = @DateReturned " +
                                                "WHERE BorrowInfoID = @id ";
                _cn.Execute(query, parameters);
            }
        }
    }
}