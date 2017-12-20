using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeChoreMapper.Models.Data
{
    public class HomesUsersChores
    {
        public int HomeID { get; set; }
        public string Homename { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public int ChoreID { get; set; }
        public string Chorename { get; set; }
        public DateTime DateCompleted { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Comments { get; set; } = "";
    }
}