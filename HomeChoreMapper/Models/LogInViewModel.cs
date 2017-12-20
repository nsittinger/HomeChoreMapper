using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChoreMapper.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "User Name:")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A home name is required")]
        [Display(Name = "Home Name:")]
        public string Homename { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}