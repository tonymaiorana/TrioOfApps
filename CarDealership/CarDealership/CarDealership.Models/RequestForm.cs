using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class RequestForm
    {
        public int VehicleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string BestTimeToCall { get; set; } //TextBox
        public PreferedContactMethod PreferedContactMethod { get; set; } //Radio Buttons or Dropdown
        public DateTime DateNeedToPurchaseBy { get; set; } //EditorFor
        public string AdditionalInfo { get; set; }
        public DateTime LastContacted { get; set; } //EditorFor
        public RequestFormStatus RequestFormStatus { get; set; } //DropDown
        public int UserAccountId { get; set; }
    }
}
