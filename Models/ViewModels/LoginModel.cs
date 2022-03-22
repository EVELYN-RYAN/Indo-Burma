using System;
using System.ComponentModel.DataAnnotations;

namespace Indo_Burma.Models.ViewModels
{
    //Defining the login credentials for potential admins
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
