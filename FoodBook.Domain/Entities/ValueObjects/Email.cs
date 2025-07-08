using System;
using System.Text.RegularExpressions; 

namespace FoodBook.Domain 
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value) || !IsValidEmail(value))
            {
                throw new ArgumentException("Invalid email format");
            }
            Value = value;
        }


        private bool IsValidEmail(string email)
        {

            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}