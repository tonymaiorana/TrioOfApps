using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class RequestForm
    {
        public int RequestFormId { get; set; }
        public int VehicleId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string BestTimeToCall { get; set; } //TextBox
        public PreferedContactMethod PreferedContactMethod { get; set; } //Radio Buttons or Dropdown

        [DataType(DataType.Date)]
        public DateTime? DateNeedToPurchaseBy { get; set; } //EditorFor

        public string AdditionalInfo { get; set; } //TextBox
        public DateTime? LastContacted { get; set; } //EditorFor
        public RequestFormStatus RequestFormStatus { get; set; } //DropDown
    }
}