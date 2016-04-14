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
        public Director Director { get; set; }
        public Studio Studio { get; set; }
        public MPAARating MPAARating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public BorrowInfo BorrowInfo { get; set; }
        public List<Actor> DvdActors { get; set; }
        public Dictionary<string,string> UserComments { get; set; } 
        public bool IsAvailable { get; set; }

        public Dvd()
        {
            Director = new Director();
            Studio = new Studio();
            BorrowInfo = new BorrowInfo();
            DvdActors = new List<Actor>();
            UserComments = new Dictionary<string, string>();
        }
    }
}