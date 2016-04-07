using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLibrary.Data;
using DvdLibrary.Models;

namespace DvdLibrary.BLL
{
    public class DvdOperations
    {
        private DvdRepository _repo = new DvdRepository();

        public void AddDirector(Dvd currentDvd)
        {

            if (_repo.CheckDirectorByName(currentDvd.DirectorName) == false)
            {
                _repo.AddDirector(currentDvd.DirectorName);
            }
        }
    }
}
