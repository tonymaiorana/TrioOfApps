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

        public List<BorrowInfo> GetAll()
        {
            using (SqlConnection cn = new SqlConnection(
               ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                List<BorrowInfo> borrowInfoList = new List<BorrowInfo>();

                return borrowInfoList;
            }
        }

        public BorrowInfo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BorrowInfo GetByDvdId(int dvdId)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString))
            {
                var borrowInfoList = cn.Query<BorrowInfo>("SELECT BorrowInfo.DvdId, BorrowInfo.BorrowerId,BorrowInfo.BorrowStartDate, BorrowInfo.BorrowEndDate" +
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

            return model;
        }

        public void Update(int id, BorrowInfo model)
        {
            BorrowInfoList = GetAll();
            BorrowInfo b = BorrowInfoList.SingleOrDefault(bb => bb.BorrowInfoId == id);
            b.BorrowInfoId = id;
            b.DvdId = model.DvdId;
            b.BorrowerId = model.BorrowerId;
            b.BorrowStartDate = model.BorrowStartDate;
            b.BorrowEndDate = model.BorrowEndDate;
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