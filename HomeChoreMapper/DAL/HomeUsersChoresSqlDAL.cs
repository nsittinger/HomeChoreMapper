using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HomeChoreMapper.Models;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.DAL
{
    public class HomeUsersChoresSqlDAL :IHomeUsersChoresDAL
    {
        private const string getHUCSql = "SELECT * FROM homes_users_chores WHERE homename = @homename;";
        private const string addCompletedChoreSQL = "INSERT INTO homes_users_chores VALUES(@homeID, @homename, @userID, @username, @choreID, @chorename, @dateCompleted, @comments);";

        private readonly string connectionString;

        public HomeUsersChoresSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public List<HomesUsersChores> GetHUCList(string homename)
        {
            List<HomesUsersChores> HUCList = new List<HomesUsersChores>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getHUCSql, conn);
                    //cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@homename", homename);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        HomesUsersChores HUC = new HomesUsersChores()
                        {
                            Homename = Convert.ToString(reader["homename"]),
                            Username = Convert.ToString(reader["username"]),
                            Chorename = Convert.ToString(reader["chorename"]),
                            DateCompleted = Convert.ToDateTime(reader["dateCompleted"]),
                            Comments = Convert.ToString(reader["comments"]),
                        };

                        HUCList.Add(HUC);
                    }

                    return HUCList;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool AddCompletedChoreSQL(HomesUsersChores HUC)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(addCompletedChoreSQL, conn);
                    cmd.Parameters.AddWithValue("@homeID", HUC.HomeID);
                    cmd.Parameters.AddWithValue("@homename", HUC.Homename);
                    cmd.Parameters.AddWithValue("@userID", HUC.UserID);
                    cmd.Parameters.AddWithValue("@username", HUC.Username);
                    cmd.Parameters.AddWithValue("@chorename", HUC.Chorename);
                    cmd.Parameters.AddWithValue("@choreID", HUC.ChoreID);
                    cmd.Parameters.AddWithValue("@dateCompleted", DateTime.Now);
                    cmd.Parameters.AddWithValue("@comments", HUC.Comments);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch (SqlException)
            {
                return false;
                throw;
            }
        }
    }
}