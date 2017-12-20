using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Data.SqlClient;
using HomeChoreMapper.Models;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.DAL
{
    public class UserSqlDAL : IUserDal
    {
        private const string getUserSQL = "SELECT TOP 1 * FROM users WHERE username = @username;";
        private const string createUserSQL = "INSERT INTO users VALUES(@username, @email, @homename, @password, @salt);";

        private readonly string connectionString;

        public UserSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User GetUser(string username)
        {
            User user = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getUserSQL, conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        user = new User
                        {
                            UserID = Convert.ToInt32(reader["userID"]),
                            Username = Convert.ToString(reader["username"]),
                            Email = Convert.ToString(reader["email"]),
                            Homename = Convert.ToString(reader["homename"]),
                            Password = Convert.ToString(reader["password"]),
                            Salt = Convert.ToString(reader["salt"])
                        };
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return user;
        }

        public bool CreateUser(User newUser)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(createUserSQL, conn);
                    cmd.Parameters.AddWithValue("@username", newUser.Username);
                    cmd.Parameters.AddWithValue("@email", newUser.Email);
                    cmd.Parameters.AddWithValue("@homename", newUser.Homename);
                    cmd.Parameters.AddWithValue("@password", newUser.Password);
                    cmd.Parameters.AddWithValue("@salt", newUser.Salt);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (SqlException ex)
            {
                return false;
                throw;
            }
        }
    }
}