using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDealership.Models
{
    public class RequestInformation
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BestTimeToCall { get; set; }
        public string PreferredContactMethod { get; set; }
        public int? TimeframeToPurchase { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime? LastContactDate { get; set; }
        public string StatusOfRequest { get; set; }

    }
}
