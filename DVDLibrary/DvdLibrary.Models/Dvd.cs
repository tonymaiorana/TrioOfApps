using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public string Title { get; set; }        
        public double AverageRating { get; set; }
        public Studio Studio { get; set; }
        public Director Director { get; set; }
        public MPAARating MPAARating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public BorrowInfo BorrowInfo { get; set; }
        public List<Actor> Actors { get; set; }        
    }
}
