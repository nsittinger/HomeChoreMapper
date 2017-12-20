using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace HomeChoreMapper.Models
{
    public class NewUserViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "A username is required")]
        [MinLength(6, ErrorMessage = "Username must be at least 6 characters long")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "An Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Home Name")]
        [Required(ErrorMessage = "A home name is required")]
        [MinLength(6, ErrorMessage = "Home name must be at least 6 characters long")]
        public string Homename { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "A Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}