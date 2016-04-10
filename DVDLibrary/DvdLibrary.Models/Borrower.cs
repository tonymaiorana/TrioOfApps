using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models
{
    public class Borrower : IValidatableObject
    {
        public int BorrowerId { get; set; }
        public string BorrowerFirstName { get; set; }
        public string BorrowerLastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string BorrowerPhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(BorrowerFirstName))
            {
                errors.Add(new ValidationResult("Please enter your first name", new[] { "First Name" }));
            }
            if (string.IsNullOrEmpty(BorrowerLastName))
            {
                errors.Add(new ValidationResult("Please enter your last name", new[] { "Last Name" }));
            }
            if (string.IsNullOrEmpty(BorrowerPhoneNumber))
            {
                errors.Add(new ValidationResult("Please enter a valid phone number", new[] { "Phone Number" }));
            }

            return errors;
        }
    }
}