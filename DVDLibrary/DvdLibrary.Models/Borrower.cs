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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
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