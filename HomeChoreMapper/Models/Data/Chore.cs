using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeChoreMapper.Models.Data
{
    public class Chore
    {
        public int ChoreID { get; set; }
        public string Chorename { get; set; }
        public string Frequency { get; set; }
        public string Description { get; set; }
        public int HomeID { get; set; }
    }
}