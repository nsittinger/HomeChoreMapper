using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.Models
{
    public class ChoreList
    {
        public List<SelectListItem> ChoresList { get; set; }
    }
}