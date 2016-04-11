using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Data.Interfaces
{
    internal interface IBorrowInfoRepository
    {
        List<BorrowInfo> GetAll();

        BorrowInfo GetById(int id);

        BorrowInfo GetByDvdId(int dvdId);

        BorrowInfo AddBorrowInfo(BorrowInfo model);

        void Update(int id, BorrowInfo model);

        void Delete(int id);
    }
}