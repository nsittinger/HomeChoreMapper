using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeChoreMapper.Models.Data
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Homename { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}