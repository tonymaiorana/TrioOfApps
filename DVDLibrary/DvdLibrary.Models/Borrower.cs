using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DvdLibrary.Models
{
    public class Borrower : IValidatableObject
    {
        public int BorrowerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [RegularExpression(@"\d{7}", ErrorMessage = "Please Enter Your 7 digit Phone Number, Numbers Only")]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("Please enter your first name", new[] { "First Name" }));
            }
            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Please enter your last name", new[] { "Last Name" }));
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                errors.Add(new ValidationResult("Please enter a valid phone number", new[] { "Phone Number" }));
            }

            return errors;
        }
    }
}