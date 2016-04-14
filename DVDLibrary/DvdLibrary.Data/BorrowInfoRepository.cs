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
                var borrowInfoList = _cn.Query<BorrowInfo>("SELECT * FROM BorrowInfo").ToList();
                return borrowInfoList;
            }
        }

        public BorrowInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BorrowInfo GetByBorrowerId(int borrowerId)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var borrowInfoList = _cn.Query<BorrowInfo>("SELECT BorrowInfo.DvdID, BorrowInfo.BorrowerId,BorrowInfo.DateBorrowed, BorrowInfo.DateReturned" +
                                             "FROM BorrowInfo").ToList();
                return
                    borrowInfoList.FirstOrDefault(
                        b => b.Borrower.BorrowerId == borrowerId);
            }
        }

        public BorrowInfo GetByDvdId(int dvdId)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var borrowInfoList = _cn.Query<BorrowInfo>("SELECT BorrowInfo.DvdID, BorrowInfo.BorrowerId,BorrowInfo.DateBorrowed, BorrowInfo.DateReturned" +
                                             "FROM BorrowInfo").ToList();
                return
                    borrowInfoList.FirstOrDefault(
                        b => b.Dvd.DvdId == dvdId);
            }
        }

        public BorrowInfo AddBorrowInfo(BorrowInfo model)
        {
            BorrowInfoList = GetAll();
            BorrowInfoList.Add(model);
            using (var _cn = new SqlConnection(constr))
            {
                var parameters = new DynamicParameters();

                parameters.Add("DvdID", model.Dvd.DvdId);
                parameters.Add("BorrowerID", model.Borrower.BorrowerId);
                parameters.Add("DateBorrowed", model.DateBorrowed);
                parameters.Add("DateReturned", model.DateReturned);
                parameters.Add("UserRating", model.BorrowerRating);
                parameters.Add("UserComments", model.BorrowerComment);
                parameters.Add("IsActive", model.IsActive);

                string query = "INSERT INTO BorrowInfo (DvdID, BorrowerID, DateBorrowed, DateReturned, UserRating, UserComments, IsActive) VALUES (@DvdID, @BorrowerID, @DateBorrowed, @DateReturned, @UserRating, @UserComments, @IsActive) ";
                _cn.Execute(query, parameters);
            }

            return model;
        }

        public void Update(int id, BorrowInfo model)
        {
            BorrowInfoList = GetAll();
            BorrowInfo b = BorrowInfoList.SingleOrDefault(bb => bb.BorrowInfoId == id);
            b.BorrowInfoId = id;
            b.Dvd.DvdId = model.Dvd.DvdId;
            //b.BorrowerId = model.BorrowerId; TEMPORARY COMMENT
            b.DateBorrowed = model.DateBorrowed;
            b.DateReturned = model.DateReturned;
            b.BorrowerRating = model.BorrowerRating;
            b.BorrowerComment = model.BorrowerComment;
        }

        public void Delete(int id)
        {
            BorrowInfoList = GetAll();
            var borrowInfoToRemove = BorrowInfoList.FirstOrDefault(b => b.BorrowInfoId == id);
            borrowInfoToRemove.IsActive = false;
        }
    }
}