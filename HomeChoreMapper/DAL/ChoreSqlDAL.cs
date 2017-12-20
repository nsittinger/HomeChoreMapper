using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HomeChoreMapper.Models;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.DAL
{
    public class ChoreSqlDAL : IChoreDal
    {
        private const string getChoreSQL = "SELECT TOP 1 * FROM chores WHERE chorename = @chorename;";
        private const string getChoreListSQL = "SELECT * FROM chores WHERE homeID = @homeID OR homeID = 0;";

        private readonly string connectionString;

        public ChoreSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Chore GetChore(string chorename)
        {
            Chore chore = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getChoreSQL, conn);
                    cmd.Parameters.AddWithValue("@chorename", chorename);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        chore = new Chore
                        {
                            ChoreID = Convert.ToInt32(reader["choreID"]),
                            Chorename = Convert.ToString(reader["chorename"]),
                            Frequency = Convert.ToString(reader["frequency"]),
                            Description = Convert.ToString(reader["description"]),
                            HomeID = Convert.ToInt32(reader["homeID"])
                        };
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return chore;
        }

        public List<Chore> GetChoreList(int homeID)
        {
            List<Chore> choreList = new List<Chore>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(getChoreListSQL, conn);
                    cmd.Parameters.AddWithValue("homeID", homeID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Chore chore = new Chore()
                        {
                            ChoreID = Convert.ToInt32(reader["choreID"]),
                            Chorename = Convert.ToString(reader["chorename"]),
                            Frequency = Convert.ToString(reader["frequency"]),
                            Description = Convert.ToString(reader["description"]),
                            HomeID = Convert.ToInt32(reader["homeID"]),
                        };

                        choreList.Add(chore);
                    }

                    return choreList;
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

    }
}