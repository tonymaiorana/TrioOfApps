﻿namespace CarDealership.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; } 
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
