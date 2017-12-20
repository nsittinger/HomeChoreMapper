using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.DAL
{
    public interface IHomeDal
    {
        bool RegisterHome(Home newHome);
        Home GetHome(string homeName);
    }
}