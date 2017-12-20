using System.Web;
using System.Net.Mail;
using System.Data.SqlClient;
using HomeChoreMapper.Models;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.DAL
{
    public interface IUserDal
    {
        User GetUser(string username);
        bool CreateUser(User newUser);
    }
}