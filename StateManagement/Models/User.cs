using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StateManagement.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid name.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid name.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid username.")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9{5,30}]+@[a-zA-A0-9{5,10}]+\.[a-zA-Z0-9{2,3}]+$", ErrorMessage = "Incorrect E-mail Format!")]
        public string Email { get; set; }

        public int Age { get; set; }

        [Required]
        public string Password { get; set; }


        public User(string firstName, string lastName, string username, string email, int age, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = username;
            Email = email;
            Age = age;
            Password = password;
        }

        public User() { }
    }
}