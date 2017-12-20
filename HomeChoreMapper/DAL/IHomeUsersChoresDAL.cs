using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HomeChoreMapper.Models;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.DAL
{
    public interface IHomeUsersChoresDAL
    {
        List<HomesUsersChores> GetHUCList(string homename);
        bool AddCompletedChoreSQL(HomesUsersChores HUC);
    }
}