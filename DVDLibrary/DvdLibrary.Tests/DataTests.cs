using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Data;
using DvdLibrary.Models;
using NUnit.Framework;

namespace DvdLibrary.Tests
{
    [TestFixture]
    class DataTests
    {
        private MockDvdRepository _Mock = new MockDvdRepository();

        [TestCase(1, "Pokemon 2000", 1, 1, 1)]
        public void GetDvdById_Test(int dvdId, string expectedTitle, int expectedBorrowInfoId, int expectedBorrowerId, int expectedDirectorId)
        {
            Assert.AreEqual(expectedTitle, _Mock.GetDvdById(dvdId).Title);
            Assert.AreEqual(expectedBorrowInfoId, _Mock.GetDvdById(dvdId).BorrowInfo.BorrowInfoId);
            Assert.AreEqual(expectedBorrowerId, _Mock.GetDvdById(dvdId).BorrowInfo.Borrower.BorrowerId);
            Assert.AreEqual(expectedDirectorId, _Mock.GetDvdById(dvdId).Director.DirectorId);
        }

        [TestCase("Warner", 1, "Warner")]
        public void GetStudioByName_Test2(string studioName, int expectedStudioId, string expectedStudioName)
        {
                Assert.AreEqual(expectedStudioName, _Mock.GetStudioByName(studioName).StudioName);
                Assert.AreEqual(expectedStudioId, _Mock.GetStudioByName(studioName).StudioId);          
        }
    }
}
