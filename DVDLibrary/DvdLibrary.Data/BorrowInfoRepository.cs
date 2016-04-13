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

        public BorrowInfo GetByDvdId(int dvdId)
        {
            using (var _cn = new SqlConnection(constr))
            {
                var borrowInfoList = _cn.Query<BorrowInfo>("SELECT BorrowInfo.DvdID, BorrowInfo.BorrowerId,BorrowInfo.DateBorrowed, BorrowInfo.DateReturned" +
                                             "FROM BorrowInfo").ToList();
                return
                    borrowInfoList.FirstOrDefault(
                        b => b.DvdId == dvdId);
            }
        }

        public BorrowInfo AddBorrowInfo(BorrowInfo model)
        {
            BorrowInfoList = GetAll();
            BorrowInfoList.Add(model);
            using (var _cn = new SqlConnection(constr))
            {
                string query = "INSERT INTO BorrowInfo (DvdID, BorrowerID, DateBorrowed, DateReturned, UserRating, UserComments) VALUES (@DvdID, @BorrowerID, @DateBorrowed, @DateReturned, @UserRating, @UserComments) ";
                _cn.Execute(query, new { model.DvdId, model.Borrower.BorrowerId, model.DateBorrowed, model.DateReturned });
            }

            return model;
        }

        public void Update(int id, BorrowInfo model)
        {
            BorrowInfoList = GetAll();
            BorrowInfo b = BorrowInfoList.SingleOrDefault(bb => bb.BorrowInfoId == id);
            b.BorrowInfoId = id;
            b.DvdId = model.DvdId;
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