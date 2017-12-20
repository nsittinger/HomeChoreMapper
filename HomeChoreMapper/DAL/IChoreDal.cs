using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.DAL
{
    public interface IChoreDal
    {
        Chore GetChore(string chorename);
        List<Chore> GetChoreList(int homeID);
    }
}