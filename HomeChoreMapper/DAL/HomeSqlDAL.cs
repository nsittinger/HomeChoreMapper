using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.DAL
{
    public class HomeSqlDAL :IHomeDal
    {
        public const string registerHomeSQL = "INSERT INTO homes VALUES(@homename);";
        public const string getHomeSQL = "SELECT TOP 1 * FROM homes WHERE homename = @homename;";

        private readonly string connectionString;

        public HomeSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool RegisterHome(Home newHome)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(registerHomeSQL, conn);
                    cmd.Parameters.AddWithValue("@homename", newHome.Homename);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0;
                }
            }
            catch(SqlException ex)
            {
                return false;
                throw;
            }
        }

        public Home GetHome(string homeName)
        {
            Home home = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(getHomeSQL, conn);

                    cmd.Parameters.AddWithValue("@homename", homeName);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        home = new Home
                        {
                            HomeID = Convert.ToInt32(reader["homeID"]),
                            Homename = Convert.ToString(reader["homeName"])
                        };
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }

            return home;
        }
    }
}